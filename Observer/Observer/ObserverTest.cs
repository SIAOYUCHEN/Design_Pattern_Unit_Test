using System;
using NUnit.Framework;

namespace Observer
{
  [TestFixture]
  public class ObserverTest
  {
    [Test]
    public void Test1()
    {
      IObserverable podcast = new PodcastA();
      IObserver student = new Student(podcast);
      podcast.Add(student);

      //預設節目是英文廣播
      podcast.NotifyObservers();

      //節目變為今年流行歌
      podcast.SetName("今年流行歌");

      podcast.NotifyObservers();
      
    }
    
    [Test]
    public void Test2()
    {
      var latestReporter = new LatestReporter();
      var threeDaysAverageReporter = new ThreeDaysAverageReporter();
      
      var rainFall = new Rainfall();
      
      rainFall.AddReporter(latestReporter);
      rainFall.AddReporter(threeDaysAverageReporter);

      AddQuantities(0, 0, 0, 30, rainFall);
      
      Assert.AreEqual(30, latestReporter.GetLatest());
      Assert.AreEqual(10, threeDaysAverageReporter.GetThreeDaysAverage());
    }

    private void AddQuantities(int quantity1, int quantity2, int quantity3, int quantity4, Rainfall rainFalls)
    {
      rainFalls.AddQuantity(quantity1);
      rainFalls.AddQuantity(quantity2);
      rainFalls.AddQuantity(quantity3);
      rainFalls.AddQuantity(quantity4);
    }
  }
}