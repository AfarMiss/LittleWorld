# Linq查询式

```
int[] numbers = { 0, 30, 20, 15, 90, 85, 40, 75 };
IEnumerable query = 
numbers.Where((number, index) => number <= index * 10);
foreach (int number in query)
 { 
   Console.WriteLine(number); 
 } 
 /* 
 This code produces the following output:
0 
20 
15 
40 
*/
```

&#x20;

```
  public class Student
    {
        public string name { get; set; }
        public int score { get; set; }
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            // 學生的名稱和成績
            List<Student> students = new List<Student> {
                                       new Student { name = "Huadi", score = 90},
                                       new Student { name = "Jason", score = 80},
                                       new Student { name = "Tim", score = 85},
                                       new Student { name = "Vicky", score = 47},
                                       new Student { name = "Anny", score = 65},
                                       new Student { name = "Eric", score = 43} };
 
            // 使用 from, where, select 標準查詢子來找出及格的學生
            var query = from stu in students
                        where stu.score >= 60
                        select stu;
 
            foreach (var q in query)
            {
                Console.WriteLine("Name = \"{0}\", Score = {1}", q.name, q.score);
            }
            Console.Read();
        }
    }
```

&#x20;

一開始先產生一個型別是 Student 的 List 集合

接著利用 from…in 來查詢每個學生（像是 foreach 一樣）

並用 where 做出判斷式（像是 if 一樣，可以放入判斷式）

最後使用 select 取得查詢物件（若只想取得 name 或是 score，也可以使用 stu.name 或 stu.score）



### 排序（orderby）

&#x20;

AdvertisementsREPORT THIS AD

List\<T> 本身就有提供排序的方法「Sort」或是 LINQ 提供的擴充方法「orderby」

使用 Sort 的方法，還得寫妥派函式去執行，並且執行的內容還得自行撰寫

或許你也可以透過 lambda 表述式，搭配 Sort 來完成

「orderby」則也是可以使用 lambda 表述式來做到排序的動作

但 LINQ 的話，就如同上面查詢一樣，只是要多用一個「orderby」的查詢子就能做到排序的動作

&#x20;

```
            // 使用 from, where, select 和 orderby 來排序及格的學生
            var query2 = from stu in students
                         where stu.score >= 60
                         orderby stu.score
                         select stu;
```

&#x20;

上述範例是將成績及格的學生，從小到大排列

若是要從大排到小，則只要在 stu.score 前加上一個「負」號

&#x20;

```
            // 使用 from, where, select 和 orderby 來排序及格的學生
            var query2 = from stu in students
                         where stu.score >= 60
                         orderby -stu.score
                         select stu;
```

&#x20;

***

### select

&#x20;

在做完查詢後，select 可以選擇要回傳的內容

上面的範例都是使用整筆資料「select stu」（在 T-SQL 會使用 SELECT \*來表示）

AdvertisementsREPORT THIS AD

但其實 select 可以回傳你想要回傳的資料，甚至是產生一個新的資料結構（類別）回傳

假設，我們每筆資料有很多屬性，但我們只需要回傳其中幾個而已

可以使用下列方法：

&#x20;

```
    public class Student
    {
        public string name { get; set; }
        public string id { get; set; }
        public int score { get; set; }
        public string phone { get; set; }
        public string location { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // 學生的名稱、成績、學號、電話和座位
            List<Student> students = new List<Student> { 
                                       new Student { name = "Huadi", score = 90, id = "10001", phone = "0987654321", location = "A3"},
                                       new Student { name = "Jason", score = 80, id = "10002", phone = "0987654324", location = "B1"},
                                       new Student { name = "Tim", score = 85, id = "10003", phone = "0987654323", location = "D4"},
                                       new Student { name = "Vicky", score = 47, id = "10004", phone = "0987654326", location = "C2"},
                                       new Student { name = "Anny", score = 65, id = "10005", phone = "0987654322", location = "A2"},
                                       new Student { name = "Eric", score = 43, id = "10006", phone = "0987654325", location = "B4"} };

            // 使用 from, where, select 標準查詢子來找出不及格的學生
            var query = from stu in students
                        where stu.score < 60
                        select new { ID = stu.id, Score = stu.score, Phone = stu.phone };

            foreach (var q in query)
            {
                Console.WriteLine("ID = \"{0}\", Score = {1}, Phone = {2}", q.ID, q.Score, q.Phone); 
            }

            Console.Read();
        }
    }
```

&#x20;

可以看到 select 後面使用 new 關鍵字

接著大括號裡可以自訂變數名稱，並將對應的值丟進去

下方讀值時，就直接呼叫剛才我們自訂的變數名稱即可

此做法常常會用在資料欄位很多，但只想要取某些值

或是有很多份內容，但想要合併（Group）之後輸出成另一份

而且在資料庫讀取上，如果只取特定的某些內容

也可以省下讀取的時間

参考

1.简单linq查询[https://kw0006667.wordpress.com/2013/05/29/clinq%E7%B0%A1%E5%96%AE%E4%BD%BF%E7%94%A8-from-where-select/](https://kw0006667.wordpress.com/2013/05/29/clinq%E7%B0%A1%E5%96%AE%E4%BD%BF%E7%94%A8-from-where-select/)