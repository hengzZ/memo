# coding: utf-8
import os
import sys
import argparse
import csv


def get_parser():
    """
    create a parser to config the picker.
    """
    parser = argparse.ArgumentParser(description='emon picker')
    parser.add_argument('--emon_csv_file', dest='csv_file', default=None, help='please specify an emon csv file, such as: __edp_socket_view_summary.csv.')
    parser.add_argument('--index_cfg', dest='index_cfg', default='index', help='specify an index cfg file. (default: index)')
    parser.add_argument('--report_layout', dest='report_layout', default='horizontal', help='specify the report layout: horizontal or vertical. (default: horizontal)')
    return parser


class Picker():
    def __init__(self, index_cfg='index', report_layout='horizontal'):
        self.index_cfg = index_cfg
        self.report_layout = report_layout
        self.config(self.index_cfg)
    
    def config(self, index_cfg):
        self.coordinates = []
        with open(index_cfg) as f:
            for line in f:
                items = line.strip().strip('(').strip(')').split(',')
                metric = items[0].strip().strip('\"').strip('\'')
                idx = int(items[1].strip().strip('\"').strip('\''))
                self.coordinates.append((metric, idx))

    def pick(self, csv_file):
        self.report = []
        for metric,idx in self.coordinates:
            with open(csv_file) as f:
                reader = csv.reader(f)
                first_row = next(reader)
                for row in reader: # 2rd to end
                    if metric.strip() == row[0].strip():
                        self.report.append(float(row[idx-1].strip()))
                        break
        return self.report

    def export(self, export_filename='report.csv'):
        with open(export_filename, 'w', newline='') as f:
            csv_writer = csv.writer(f)
            if 'horizontal' == self.report_layout:
                csv_writer.writerow(self.report)
            elif 'vertical' == self.report_layout:
                for item in self.report:
                    csv_writer.writerow((item,))



if __name__ == '__main__':
    parser = get_parser()
    args = parser.parse_args()

    csv_file = args.csv_file
    index_cfg = args.index_cfg
    report_layout = args.report_layout
    if csv_file is None or not ('horizontal'== report_layout or 'vertical' == report_layout):
        print('\nPlease check the arguments you entered.\n\n')
        parser.print_help()
        sys.exit(-1)

    picker = Picker(index_cfg, report_layout)
    report = picker.pick(csv_file)
    picker.export()

