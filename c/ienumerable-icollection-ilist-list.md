# IEnumerable/ICollection/IList/List

<figure><img src="../.gitbook/assets/Zeichnung-IEnumerable-ICollection-IList.png" alt=""><figcaption></figcaption></figure>



| Interface                    | Scenario                                                                                                                                                                                                                                                      |
| ---------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| IEnumerable, IEnumerable\<T> | The only thing you want is to iterate over the elements in a collection. You only need read-only access to that collection.                                                                                                                                   |
| ICollection, ICollection\<T> | You want to modify the collection or you care about its size.                                                                                                                                                                                                 |
| IList, IList\<T>             | You want to modify the collection and you care about the ordering and / or positioning of the elements in the collection.                                                                                                                                     |
| List, List\<T>               | Since in object oriented design you want to [depend on abstractions instead of implementations](https://en.wikipedia.org/wiki/Dependency\_inversion\_principle), you should never have a member of your own implementations with the concrete type List/List. |

简而言之，如果只需要读取数据，那么应该使用IEnumerable，如果需要修改数据或是需要知晓集合长度，那么使用ICollection，如果需要排序或者知晓位置，那么使用IList。

在面向对象的思想下，参数应避免使用具体实现来代替抽象接口。这样的代码具有更好的灵活性。

## 参考资料

1. [https://www.claudiobernasconi.ch/2013/07/22/when-to-use-ienumerable-icollection-ilist-and-list/](https://www.claudiobernasconi.ch/2013/07/22/when-to-use-ienumerable-icollection-ilist-and-list/)
