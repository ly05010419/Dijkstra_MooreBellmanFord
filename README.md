# 目的：两点的最短距离


## Dijkstra
> 1. 初始化
> 2. 已访问集合V 和 未访问集合W
> 3. V={startNode},W={andere Node}   
> 4. 更新startNode的所有子节点，加入V，去掉startNode
> 5. V找到最短节点w作为新的startNode 然后回到4）

## 圖示

![GITHUB](https://upload.wikimedia.org/wikipedia/commons/5/57/Dijkstra_Animation.gif "git圖示")



## MooreBellmanFord

> 遍历所以边，更新节点的weight，此过程循环Anzahl von Node 遍。


## 参考
http://www.cnblogs.com/gaochundong/p/dijkstra_algorithm.html
http://www.cnblogs.com/gaochundong/p/bellman_ford_algorithm.html




TUM算法详解
http://www-m9.ma.tum.de/Allgemeines/GraphAlgorithmenEn
