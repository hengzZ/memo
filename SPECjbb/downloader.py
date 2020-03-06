import os
import sys

import requests
import urllib
import gzip


def get_headers(url):
    #resp = requests.head(url, proxies={"http":"http://wpad.intel.com/wpad.dat","https":"https://child-prc.intel.com:913"})
    resp = requests.head(url)
    print(resp.headers)
    return resp.headers


def urllib_download(link, filename):
    #httpproxy_handler = urllib.request.ProxyHandler({"http":"http://wpad.intel.com/wpad.dat","https":"https://child-prc.intel.com:913"})
    nullproxy_handler = urllib.request.ProxyHandler({})
    opener = urllib.request.build_opener(nullproxy_handler)
    req = urllib.request.Request(link)
    resp = opener.open(req)
    with open(filename, 'wb') as f:
        data = resp.read()
        f.write(data)


def download_file(link, filename):
    headers = {'Proxy-Connection':'keep-alive', 'accept-encoding':'gzip'}
    #resp = requests.get(link, stream=True, headers=headers, proxies={"http":"http://wpad.intel.com/wpad.dat","https":"https://child-prc.intel.com:913"})
    resp = requests.get(link, stream=True, headers=headers)
    print('status code: ', resp.status_code)
    with open(filename, 'wb') as f:
        for chunk in resp.iter_content(chunk_size=512):
            if chunk:
                f.write(chunk)


def main():
    for id in range(1229, 1230):
        link = 'http://pic.uartist.cn/books/bookcontent/{0}/{0}.zip'.format(id)
        filename = '{0}.zip'.format(id)
        print(link, filename)
        get_headers(link)
        #download_file(link, filename)
        urllib_download(link, filename)


if __name__ == '__main__':
    main()
