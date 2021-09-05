using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Hw7;
using Xunit;

namespace Hw7Test
{
    public class UnitTest1
    {
        List<Note> TestList() => new List<Note>()
        {
            new Note()
            {
                Description = "Test1", Phone = "123123", Subject = "test", CreationDate = new DateTime(2020, 1, 1)
            },
            new Note()
            {
                Description = "Test2", Phone = "123123", Subject = "test", CreationDate = new DateTime(2021, 1, 1)
            },
            new Note()
            {
                Description = "Test2", Phone = "123123", Subject = "test4" /*Creation date is self init to today*/
            }
        };

        [Fact]
        public void Test_CheckFindViaIndexPropertyByDate()
        {
            List<Note> l = TestList();
            var r = l.Where(a => a.CreationDate.Equals(DateTime.Today));
            Assert.Equal(r.ToArray().Length,1);
        }

        [Fact]
        public void Test_ShouldFillListOfNotesAndGetSomeNodesByFilter()
        {
            List<Note> l = TestList();
            int cnt = 0;
            foreach (Note v in l.Where(a=>a["Subject"].Equals("test")))
            {
                Assert.True(v.Subject.Equals("test"), "Все subject в выборке должны быть test");
                cnt++;
                Debug.Print(v.ToString());
            }

            Assert.True(cnt==2,"В тесте должно быть только два прохода");
            
         
        }
    }
}