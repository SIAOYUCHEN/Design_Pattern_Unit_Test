定義：用原型的實例來指定創建的對象種類，並通過複製這些原型創造新的對象

1.有時候對象類型一開始沒辦法確定，在這類型在執行的時候確認，使用Clone出
    一個對象比較容易些
2.某些情境，我們需要對象當中的副本，使用原型模式是最佳的狀況

那上述各位就會有一個疑問了???    那為什麼不用new 一個對象勒???
A：因為 new 一個對象時候...其一不能獲取目前對象的狀態，其二就算複製目前的對象
      效率不如原型模式，其三在使用原型模式的時候，將原來的對象複製一個出來，這
      個對象就跟目前的對象是完全一致了。

參考來源:

https://dotblogs.com.tw/bda605/2019/07/22/110236
