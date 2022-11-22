using Luck.Framework.Extensions;

namespace Luck.Walnut.Infrastructure;

public static class EnumExtensions
{
    public static IDictionary<string,string> EnumsToDictionary(this Type type)
    {
        var names = Enum.GetNames(type);
        Dictionary<string,string> dictionary = new Dictionary<string,string>(names.Length);
        foreach (var name in names)
        {

            var member = type.GetMember(name).FirstOrDefault();
            if(member is null)
                dictionary.Add(name.ToString(), "");
            else
                dictionary.Add(name.ToString(), member.ToDescription());
        }
        return dictionary;

    }
}