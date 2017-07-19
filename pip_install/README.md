# install pip on Ubuntu 14.04 LTS #

## Install Pip with apt-get ##
```
sudo apt-get update
sudo apt-get -y install python-pip
```

## Install Pip with Curl and Python ##
```
curl "https://bootstrap.pypa.io/get-pip.py" -o "get-pip.py"
sudo -E python get-pip.py
```

## Verify The Installation ##
```
pip --help
pip -V
```

## reference ##
* [pip Guide][]

## **note** ##
* sudo -E   
On the assumption that your proxy settings are set in your normal user environment, but not the one you get when you run sudo.


[pip Guide]: https://pip.pypa.io/en/stable/#

