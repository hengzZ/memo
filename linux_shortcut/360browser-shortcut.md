## Linux 360 安全浏览器桌面快捷方式

#### 1. Baidu 图标创建
```python
import numpy as np
import cv2

import os
import sys
import argparse


def get_parser():
    parser = argparse.ArgumentParser(description="create ubuntu icons")
    parser.add_argument("--input_image", dest="input_image", help="original image used for icon production")
    return parser


def main():
    parser = get_parser()
    args = parser.parse_args()
    input_image = str(args.input_image)
    
    if "" == input_image or not os.path.exists(input_image):
        parser.print_help()
        return -1

    image = cv2.imread(input_image)
    rootdir = "hicolor"
    if not os.path.exists(rootdir):
        os.makedirs(rootdir)

    for imgsize in (16, 22, 24, 32, 48, 64, 128, 256):
        destdir = os.path.join(rootdir, "{0}x{0}/apps".format(imgsize))
        if not os.path.exists(destdir):
            os.makedirs(destdir)
        imagename = input_image.strip().split(".")[0]
        icon = cv2.resize(image, (imgsize,imgsize), 0, 0, cv2.INTER_LINEAR)
        cv2.imwrite(os.path.join(destdir, imagename+".png"), icon)

    return 0


if __name__ == "__main__":
    sys.exit(main())
```

#### 2. 360 / Baidu 桌面快捷方式
```bash
## Install Browser360
sudo dpkg -i browser360-beta_10.0.1008.0-1_amd64.deb

## Modify the desktop file (Remove beta notification from Name)
sudo mv /usr/share/applications/browser360-beta.desktop /usr/share/applications/browser360.desktop
sudo sed -i 's/Name=360安全浏览器 (beta)/Name=360安全浏览器/g' /usr/share/applications/browser360.desktop
# desktop shortcut
cp /usr/share/applications/browser360.desktop ~/Desktop/browser360.desktop
sed -i '1i\#!/usr/bin/env xdg-open' ~/Desktop/browser360.desktop
chmod +x ~/Desktop/browser360.desktop

## Install Baidu Icons
sudo cp -r hicolor /usr/share/icons/

## Create Baidu Desktop Shortcut
echo "#!/usr/bin/env xdg-open" >> ~/Desktop/baidu.desktop
echo "[Desktop Entry]" >> ~/Desktop/baidu.desktop
echo "Version=1.0" >> ~/Desktop/baidu.desktop
echo "Name=百度" >> ~/Desktop/baidu.desktop
echo "GenericName=Baidu" >> ~/Desktop/baidu.desktop
echo "GenericName[zh_CN]=百度" >> ~/Desktop/baidu.desktop
echo "GenericName[zh_HK]=百度" >> ~/Desktop/baidu.desktop
echo "GenericName[zh_TW]=百度" >> ~/Desktop/baidu.desktop
echo "Comment=Baidu Search" >> ~/Desktop/baidu.desktop
echo "Comment[zh_CN]=百度搜索" >> ~/Desktop/baidu.desktop
echo "Comment[zh_HK]=百度搜索" >> ~/Desktop/baidu.desktop
echo "Comment[zh_TW]=百度搜索" >> ~/Desktop/baidu.desktop
echo "Exec=/usr/bin/browser360-beta www.baidu.com" >> ~/Desktop/baidu.desktop
echo "Terminal=false" >> ~/Desktop/baidu.desktop
echo "Icon=/usr/share/icons/hicolor/64x64/apps/baidu.png" >> ~/Desktop/baidu.desktop
echo "Type=Application" >> ~/Desktop/baidu.desktop
echo "Categories=Network;WebBrowser;" >> ~/Desktop/baidu.desktop
echo "MimeType=text/html;text/xml;application/xhtml_xml;image/webp;x-scheme-handler/http;x-scheme-handler/https;x-scheme-handler/ftp;" >> ~/Desktop/baidu.desktop
sudo chmod +x ~/Desktop/baidu.desktop

## Uninstall
# sudo dpkg -r browser360-beta
# sudo rm -rf /usr/share/applications/browser360.desktop
```