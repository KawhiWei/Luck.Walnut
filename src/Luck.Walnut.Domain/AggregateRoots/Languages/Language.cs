using Luck.Walnut.Domain.Shared.Enums;

namespace Luck.Walnut.Domain.AggregateRoots.Languages;

public class Language: FullAggregateRoot
{
    public Language(string name, LanguageTypeEnum languageTypeType)
    {
        Name = name;
        LanguageTypeType = languageTypeType;
    }

    /// <summary>
    /// 语言名称
    /// </summary>
    public string Name { get; private set; } 
    
    public LanguageTypeEnum LanguageTypeType{ get; private set; }
}