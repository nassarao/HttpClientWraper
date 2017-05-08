using HttpClientFramework;

namespace QTestAPI
{
    interface IAPIActions
    {

        PostObject Create();
        string GetAll();
        PostObject GetById();
        string RemoveById(int id);
        string RemoveAll();
        PostObject Update();

    }
}
