目的：用一個工廠介面來產生一系列相關的物件，但實際建立哪些物件由實作工廠的子類別來實現

有了冒險者之後，他們還需要各種裝備才能出門探險，假如一個冒險者需要武器、頭盔、上衣、褲子、鞋子5種裝備， 村莊內又有4種不同專業的冒險者，這樣我們就要建立20種工廠類別來生產裝備，而且每增加一種冒險者類別， 就要多增加5個實體工廠類別，如果使用剛才的工廠模式來管理生產裝備，實體工廠類別就會變非常得多，這時候有點經驗的程式設計師就會意識到程式碼可能因此變雜亂不易維護。 在這種情境之下，工廠模式不能解決我們的問題，因此這邊改變一下工廠的定義，首先工廠仍然只是一個抽象介面(Factory)，但是介面規定工廠現在生產的不是一種產品， 而是生產一個冒險者類別一系列所有的裝備，也就是說一間工廠要生產武器、頭盔、上衣、褲子、鞋子5種裝備(Product)， 當然有了抽象工廠介面後當然也需要實體工廠(ConcreteFactory)，例如說鬥士裝備生產工廠就會生產一系列的鬥士裝備(ConcreteProduct) ，這就是抽象工廠模式

參考來源:
https://skyyen999.gitbooks.io/-study-design-pattern-in-java/content/abstractFactory1.html