using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using generator;
using System.IO;
using System.Collections.Generic;

namespace UnitTestCharGenerator
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            BigramsGenerator gen = new BigramsGenerator();
            SortedDictionary<char, int> stat = gen.saveToFile("results/first.txt");
            int count1 = 0;
            int count2 = 0;
            foreach (KeyValuePair<char, int> ch in stat)
            {
                if (ch.Equals('�'))
                {
                    count1++;
                }
                else if (ch.Equals('�'))
                {
                    count2++;
                }
            }
            Assert.IsTrue(count1 > count2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            BigramsGenerator gen = new BigramsGenerator();
            gen.saveToFile("results/first.txt");
            string text = File.ReadAllText("results/first.txt");
            bool flag = text.Contains("��");
            Assert.IsFalse(flag);
        }

        [TestMethod]
        public void TestMethod3()
        {
            BigramsGenerator gen = new BigramsGenerator();
            gen.saveToFile("results/first.txt");
            string text = File.ReadAllText("results/first.txt");
            string bigr1 = "��";
            string bigr2 = "��";
            int count1 = (text.Length - text.Replace(bigr1, "").Length) / bigr1.Length;
            int count2 = (text.Length - text.Replace(bigr2, "").Length) / bigr2.Length;
            Assert.IsFalse(count1 > count2);
        }


        [TestMethod]
        public void TestMethod4()
        {
            WordsGenerator gen = new WordsGenerator();
            SortedDictionary<string, int> stat = gen.saveToFile("results/second.txt");
            int count1 = 0;
            int count2 = 0;
            foreach (KeyValuePair<string, int> s in stat)
            {
                if (s.Equals("�"))
                {
                    count1++;
                }
                else if (s.Equals("�������"))
                {
                    count2++;
                }
            }
            Assert.IsTrue(count1 > count2);
        }

        [TestMethod]
        public void TestMethod5()
        {
            WordsGenerator gen = new WordsGenerator();
            SortedDictionary<string, int> stat = gen.saveToFile("results/second.txt");
            int count = 0;
            foreach (KeyValuePair<string, int> s in stat)
            {
                if (s.Equals("�"))
                {
                    count++;
                }
            }
            Assert.IsTrue(count/1000.0 > 0.1);
        }


        [TestMethod]
        public void TestMethod6()
        {
            BiWordsGenerator gen = new BiWordsGenerator();
            SortedDictionary<string, int> stat = gen.saveToFile("results/third.txt");
            int count1 = 0;
            int count2 = 0;
            foreach (KeyValuePair<string, int> s in stat)
            {
                if (s.Equals("� ��"))
                {
                    count1++;
                }
                else if (s.Equals("�������� ��"))
                {
                    count2++;
                }
            }
            Assert.IsTrue(count1 > count2);
        }

        [TestMethod]
        public void TestMethod7()
        {
            BiWordsGenerator gen = new BiWordsGenerator();
            SortedDictionary<string, int> stat = gen.saveToFile("results/third.txt");
            int count = 0;
            foreach (KeyValuePair<string, int> s in stat)
            {
                if (s.Equals("� ��"))
                {
                    count++;
                }
            }
            Assert.IsTrue(count/1000.00 > 0.03);
        }
    }
}
