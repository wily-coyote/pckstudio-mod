﻿/* Copyright (c) 2023-present miku-666
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
**/
using PckStudio.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace PckStudio.Internal {
	public sealed class Animation {
		public const int MinimumFrameTime = 1;

		public int FrameCount => _frames.Count;

		public int TextureCount => _textures.Count;

		public bool Interpolate { get; set; } = false;

		private readonly List<Image> _textures;

		private readonly IList<Frame> _frames = new List<Frame>();

		private object _syncLock = new object();

		public Animation(IEnumerable<Image> textures, bool initFramesFromTextures = false) {
			_textures = new List<Image>(textures);
			if(initFramesFromTextures)
				AddTexturesAsFrames(MinimumFrameTime);
		}

		public class Frame {
			public readonly Image Texture;
			public int Ticks {
				get {
					return _ticks;
				}
				set {
					lock(_syncObject) {
						_ticks = value;
					}
				}
			}

			private int _ticks;
			private object _syncObject = new object();

			public Frame(Image texture) : this(texture, MinimumFrameTime) { }

			public Frame(Image texture, int frameTime) {
				Texture = texture;
				Ticks = frameTime;
			}
		}

		private void CheckTextureIndex(int index) {
			if(!_textures.IndexInRange(index))
				throw new ArgumentOutOfRangeException(nameof(index));
		}

		public Frame AddFrame(int textureIndex, int frameTime) {
			CheckTextureIndex(textureIndex);
			Frame frame = new Frame(_textures[textureIndex], frameTime);
			_frames.Add(frame);
			return frame;
		}

		private void AddTexturesAsFrames(int frameTime) {
			for(int i = 0; i < TextureCount; i++) {
				AddFrame(i, frameTime);
			}
		}

		public bool RemoveFrame(int frameIndex) {
			_frames.RemoveAt(frameIndex);
			return true;
		}

		public Frame GetFrame(int index) => _frames[index];

		public IReadOnlyCollection<Frame> GetFrames() {
			return new ReadOnlyCollection<Frame>(_frames);
		}

		public IReadOnlyCollection<Frame> GetInterpolatedFrames() {
			if(Interpolate) {
				return new ReadOnlyCollection<Frame>(InternalGetInterpolatedFrames().ToList());
			}
			return GetFrames();
		}

		private IEnumerable<Frame> InternalGetInterpolatedFrames() {
			for(int i = 0; i < FrameCount; i++) {
				Frame currentFrame = _frames[i];
				Frame nextFrame = _frames[0];
				if(i + 1 < FrameCount)
					nextFrame = _frames[i + 1];
				for(int tick = 0; tick < currentFrame.Ticks; tick++) {
					double delta = 1.0f - tick / (double)currentFrame.Ticks;
					yield return new Frame(currentFrame.Texture.Interpolate(nextFrame.Texture, delta));
				}
			}
			yield break;
		}


		public IReadOnlyCollection<Image> GetTextures() {
			return _textures;
		}

		public int GetTextureIndex(Image frameTexture) {
			_ = frameTexture ?? throw new ArgumentNullException(nameof(frameTexture));
			return _textures.IndexOf(frameTexture);
		}

		public void SetFrame(int frameIndex, Frame frame) {
			lock(_syncLock) {
				_frames[frameIndex] = frame;
			}
		}

		public void SetFrame(int frameIndex, int textureIndex, int frameTime = MinimumFrameTime) {
			CheckTextureIndex(textureIndex);
			SetFrame(frameIndex, new Frame(_textures[textureIndex], frameTime));
		}

		internal void SetFrameTicks(int ticks) {
			lock(_syncLock) {
				foreach(Frame frame in _frames) {
					frame.Ticks = ticks;
				}
			}
		}

		internal void SwapFrames(int sourceIndex, int destinationIndex) {
			lock(_syncLock) {
				_frames.Swap(sourceIndex, destinationIndex);
			}
		}

		internal static Animation CreateEmpty() {
			return new Animation(Array.Empty<Image>());
		}
	}
}
