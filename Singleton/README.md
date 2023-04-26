目的：保證一個類別只會產生一個物件，而且要提供存取該物件的統一方法

單例模式： 一開始我們就直接new出這個類別的實體物件，並且將constructor宣告為private， 這樣其他程式就無法再new出新物件，如此一來就能保證這個類別只會存在一個實體物件， 這種寫法因為一開始就已經建立物件，因此也稱為貪婪單例模式(Greed Singleton)。

參考來源:
https://skyyen999.gitbooks.io/-study-design-pattern-in-java/content/singleton.html