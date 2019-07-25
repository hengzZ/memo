### emon data picker
—— emon csv 数据抓取

##### 运行
```bash
python --index_cfg [index] --report_layout [horizontal or vertical] --emon_csv_file [..summary.csv]
```

参数说明
* index_cfg 指定抓取的 metric，请注意，同时要指定第几列。 （以 Socket View Summary 为例： 第 1 列为 metric 信息，第 2 列为 Socket0 的信息，以此类推..）
* report_layout 指定导出结果 report.csv 的排布方式，横向 or 纵向。
* emon_csv_file 指定 emon csv 文件。

特别说明： <br>
index_cfg 配置文件的书写方式，参考默认提供的 index 配置文件，它与 emon __edp_socket_view_summary.csv 文件对应。
如需抓取其他 summary 文件的数据，参考对应写法即可。
