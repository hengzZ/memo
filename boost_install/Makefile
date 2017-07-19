TARGET=test
CXX=g++
CXXFLAGS= -g -O3 -Wall \
	  -std=c++11 \
	  -I/usr/local/include
CXXLIBS= -L/usr/local/lib

$(TARGET):
	$(CXX) -o $@ main.cpp $(CXXFLAGS) $(CXXLIBS)

.PHONY: clean

clean:
	rm -rf $(TARGET)



