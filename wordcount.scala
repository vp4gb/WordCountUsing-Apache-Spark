Below is the code for word count in SCALA language (in yellow highlight) with console outputs. scala> val bigdata = sc.textFile("/home/puri1513/Desktop/FinalStuff/MyFile.txt")bigdata: org.apache.spark.rdd.RDD[String] = MapPartitionsRDD[1] at textFile at <console>:27scala> val number  = bigdata.flatMap(line => line.split(" ")).map(word => (word,1)).reduceByKey(_ + _);number: org.apache.spark.rdd.RDD[(String, Int)] = ShuffledRDD[4] at reduceByKey at <console>:29scala> number.saveAsTextFile("/home/puri1513/Desktop/FinalStuff/output")                                                                                