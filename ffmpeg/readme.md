## ffmpeg

#### 从源码编译安装 ffmpeg
``` bash
•	sudo apt-get install yasm
•	sudo apt-get install libx264-dev
•	./configure --prefix=/usr/local/ --enable-gpl --enable-libx264 --enable-shared
•	make 
•	sudo make install
```

#### ffmpeg + x164
* x264 源码下载 <br>
  ftp://ftp.videolan.org/pub/videolan/x264/snapshots/last_stable_x264.tar.bz2
```bash
  tar –xvf last_x264.tar.bz2
  cd x264-snapshot-20180410-2245
  ./configure --enable-static --prefix=/usr/local/ffmpeg
  make
  make install
```
* x265 源码下载 <br>
  https://bitbucket.org/multicoreware/x265/downloads/x265_1.9.tar.gz
```bash
  cd ./build/linux/   
  ./make-Makefiles.bash
  make (or make -j)
  make install
```
* ffmpeg 安装 <br>
  https://ffmpeg.org/releases/ffmpeg-4.1.tar.bz2
```bash
# x264
  tar –xvf ffmpeg-4.0.1.tar.bz2
  ./configure --enable-static --enable-x86asm --enable-asm --enable-libx264 --enable-gpl --prefix=/usr/local/ffmpeg --extra-cflags=-I/usr/local/ffmpeg/include --extra-ldflags=-L/usr/local/ffmpeg/lib --extra-libs=-ldl
  make
  make install
# x265
 ./configure --prefix=/usr/local/ffmpeg/ --enable-static --enable-asm --enable-x86asm --enable-libx264 --enable-libx265 --enable-ffplay --enable-gpl --extra-cflags=-I/usr/local/include/  --extra-ldflags=-L/usr/local/lib --extra-cflags=-I/usr/local/ffmpeg/include/ --extra-ldflags=-L/usr/local/ffmpeg/lib/ --extra-libs=-ldl
 make
 make install
```

* x264 测试
```bash
numactl -N 0,1,2,3 -m 0,1,2,3 ./ffmpeg -i demo_video/huya_src.flv -s 1280x720 -preset:v faster -profile:v baseline -tune:v psnr -c:v libx264 -acodec copy $NUM.flv  &
```

* x265 测试
```bash
numactl -N 0,1,2,3 -m 0,1,2,3 ./ffmpeg -i ./demo_video/1280.mp4 -preset:v fast -pix_fmt yuv420p -c:v libx265 -qmin 1 -qmax 50 -x265-params input-res=1280*720 -acodec copy -y $NUM.hevc &
```
