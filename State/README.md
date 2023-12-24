目的：將物件狀態封裝成類別，此物件隨者狀態改變時有不同的行為。

Context（環境類）：環境類又稱為上下文類，它是擁有多種狀態的物件。由於環境類
的狀態存在多樣性且在不同狀態下物件的行為有所不同，因此將狀態獨立出去形成單獨
的狀態類。在環境類中維護一個抽象狀態類 State 的例項，這個例項定義當前狀態，在具
體實現時，它是一個 State 子類的物件。

State（抽象狀態類）：它用於定義一個介面以封裝與環境類的一個特定狀態相關的行為，
在抽象狀態類中聲明瞭各種不同狀態對應的方法，而在其子類中實現類這些方法，由於不
同狀態下物件的行為可能不同，因此在不同子類中方法的實現可能存在不同，相同
的方法可以寫在抽象狀態類中。

ConcreteState（具體狀態類）：它是抽象狀態類的子類，每一個子類實現一個與環境類
的一個狀態相關的行為，每一個具體狀態類對應環境的 一個具體狀態，不同的具體狀態類
其行為有所不同。

使用場景：

行為隨者狀態來改變場景
條件與分支的替代者

參考來源:


https://dotblogs.com.tw/bda605/2020/03/26/001403
