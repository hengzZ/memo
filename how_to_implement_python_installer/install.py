import os
import commands  
import argparse
  
MKLDNN_PATH = 'third_party/mkl-dnn'

def exec_cmd(cmd, title, exec_type=0):
    print ' ', title
    if exec_type == 0:
        (status, output)=commands.getstatusoutput(cmd)
        if status:
            print '\n    ERROR: ', output
            exit()
    else:
        os.system(cmd)


if __name__ == '__main__':
    parser = argparse.ArgumentParser()
    parser.add_argument("--mkldnn_path", "-p", default=MKLDNN_PATH, type=str, help="Path of mkl-dnn, default:[%s]" % MKLDNN_PATH)
    parser.add_argument("--no_test", "-n", action='store_true', help="Don't run mkl-dnn test.")
    args = parser.parse_args()

    download_mkldnn = 'git clone https://github.com/intel/mkl-dnn %s' % args.mkldnn_path
    make_mkldnn = 'mkdir -p %s/build && cd %s/build && cmake .. && make -j32' % (args.mkldnn_path, args.mkldnn_path)
    test_mkldnn = 'cd %s/build && make test -j32' % (args.mkldnn_path)

    print '\nInstall start.\n'
    if os.path.exists(args.mkldnn_path):
        print "  Exist path['third_party/mkl-dnn'], jump the step of install mkldnn."
    else:
        exec_cmd(download_mkldnn, "Cloning 'mkl-dnn' into 'third_party/mkl-dnn'...")

    exec_cmd(make_mkldnn, "Making mkl-dnn...")
    if not args.no_test:
        exec_cmd(test_mkldnn, "Testing mkl-dnn...", 1)

    print '\nDone.\n'
