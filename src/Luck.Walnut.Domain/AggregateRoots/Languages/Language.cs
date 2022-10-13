namespace Luck.Walnut.Domain.AggregateRoots.Languages;

public class Language: FullAggregateRoot
{
    public Language(string name)
    {
        Name = name;
    }

    /// <summary>
    /// 语言名称
    /// </summary>
    public string Name { get; private set; } 
}