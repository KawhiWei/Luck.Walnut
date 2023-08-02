namespace Toyar.App.Adapter.K8sAdapter.Constants;

public class ConstantsLabels
{
    public static IDictionary<string, string> GetKubeDefalutLabels()
    {
        var dic = new Dictionary<string, string>
            {
                //{ "toyar-paas", "true" },
                { "app.kubernetes.io/created-by", "toyar-paas" },
            };
        return dic;
    }
}