using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Class1
    {
        IWebDriver m_driver;

        [SetUp]
        public void startBrowser()
        {
        }
        [Test]
        public void test()
        {
            m_driver = new ChromeDriver("D:\\3rdparty\\chrome");    //place where my chromedriver is located
            m_driver.Url = "https://makaut.ucanapply.com/smartexam/public/result-details";
            long n = 10300117011;                                   //roll to start from
            
            IWebElement emailTextBox = m_driver.FindElement(By.XPath("//*[@id='username']"));
            emailTextBox.SendKeys(n.ToString());
            m_driver.FindElement(By.XPath(".//*[@id='semester']/option[4]")).Click();
            IWebElement signUpButton = m_driver.FindElement(By.XPath("//*[@id='result-search-panal']/div[2]/div[1]/button"));
            signUpButton.Click();
            string name,name1,cgpa1,cgpa11,cgpa2,cgpa21,cgpaf,cgpaf1,p_f,p_f1;
             name = m_driver.FindElement(By.XPath("//*[@id='page-wrap']/table[2]/tbody/tr[2]/td[1]")).Text;
             cgpa1 = m_driver.FindElement(By.XPath("//*[@id='page-wrap']/table[6]/tbody/tr[1]/td[1]")).Text;
             cgpa2 = m_driver.FindElement(By.XPath("//*[@id='page-wrap']/table[6]/tbody/tr[2]/td")).Text;
             cgpaf = m_driver.FindElement(By.XPath("//*[@id='page-wrap']/table[6]/tbody/tr[3]/td")).Text;
             p_f = m_driver.FindElement(By.XPath("//*[@id='page-wrap']/table[6]/tbody/tr[4]/td[1]")).Text;
            FileStream fs1 = new FileStream("D:\\Yourfile.txt", FileMode.OpenOrCreate, FileAccess.Write);                       //file path to store
            StreamWriter writer = new StreamWriter(fs1);
            writer.Write(name + "\t\t" + cgpa1 + "\t" + cgpa2 + "\t" + cgpaf + "\t" + n);
            writer.Write(Environment.NewLine);
            writer.Close();
            m_driver.FindElement(By.XPath("//*[@id='result-search-panal']/div[2]/div[3]")).Click();


            for (long i = n+1; i <= n+160; i++)
            {           
                IWebElement emailTextBox1 = m_driver.FindElement(By.XPath("//*[@id='username']"));
                emailTextBox1.SendKeys(i.ToString());
                m_driver.FindElement(By.XPath(".//*[@id='semester']/option[4]")).Click();
                IWebElement signUpButton1 = m_driver.FindElement(By.XPath("//*[@id='result-search-panal']/div[2]/div[1]/button"));
                signUpButton1.Click();
                   Boolean isPresent = m_driver.FindElements(By.XPath("/html/body/div[2]/div/div[2]/div[2]/div/div/div[2]")).Count() > 0;
                    if (isPresent == true)
                    {                      
                        name1 = m_driver.FindElement(By.XPath("//*[@id='page-wrap']/table[2]/tbody/tr[2]/td[1]")).Text;
                        cgpa11 = m_driver.FindElement(By.XPath("//*[@id='page-wrap']/table[6]/tbody/tr[1]/td[1]")).Text;
                        cgpa21 = m_driver.FindElement(By.XPath("//*[@id='page-wrap']/table[6]/tbody/tr[2]/td")).Text;
                        cgpaf1 = m_driver.FindElement(By.XPath("//*[@id='page-wrap']/table[6]/tbody/tr[3]/td")).Text;
                        p_f1 = m_driver.FindElement(By.XPath("//*[@id='page-wrap']/table[6]/tbody/tr[4]/td[1]")).Text;
                        File.AppendAllText("D:\\Yourfile.txt", name1 + "\t\t" + cgpa11 + "\t" + cgpa21 + "\t" + cgpaf1 + "\t" + i + Environment.NewLine);           //file path to append
                    m_driver.FindElement(By.XPath("//*[@id='result-search-panal']/div[2]/div[3]")).Click();
                    }
                    else
                m_driver.FindElement(By.XPath("//*[@id='result-search-panal']/div[2]/div[3]")).Click();        
            }

        }

        [TearDown]
        public void closeBrowser()
        {
            m_driver.Close();
        }

    }
}