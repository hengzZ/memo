## Boost Library Install on Ubuntu ##

1. Download archive on [Boost Site][], such as `boost_1_64_0.tar.bz2`.


2. Compile the library.

```
tar --bzip2 -xvf boost_1_64_0.tar.bz2
cd boost_1_64_0/
./bootstrap.sh
./b2
```


3. Install boost

```
sudo ./b2 install
```
note: the default directory is /usr/local/include/boost and /usr/local/lib


4. Uninstall boost

```
sudo rm –rf /usr/local/include/boost
sudo rm –rf /usr/local/lib/libboost_*
```


5. Install using apt-get 
```
sudo apt-get install --no-install-recommends libboost-all-dev
```


## More ##
For details, please read [./docs/unix-variants.html](./docs/unix-variants.html)



[Boost Site]: https://dl.bintray.com/boostorg/release/1.64.0/source/
