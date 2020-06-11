# SaveReloadSystem
# 基于Unity的游戏的存档和读档系统

使用二进制方法,XML方法,JSON方法实现游戏场景数据的存储于加载,基本流程序列化和反序列化
推荐使用json方式来保存数据,更加轻量化和便捷,本案例使用的是Newtonsoft.Json动态链接库,只需导入至工程目录下即可进行链接
Newtonsoft.Json下载地址 https://pan.baidu.com/s/1H5tG2LqXuabsfjqm-yrSLw 提取码:29mj
# 1.序列化
将对象序列化(转化为字节流[二进制],xml文档,json文档),将数据流保存至文件夹
# 2.反序列化
读取保存文件的数据,通过将数据流解析成对象的方式实现数据的读取,再将对象的数据加载到场景中即可实现加载功能
