using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthwindApp.View
{
    public interface IBaseView<T>
    {
        void OnLoadData(IList<T> list);
        void OnSaved(T obj);
        void OnUpdated(T obj);
        void OnDeleted(T obj);
        void OnFailed(string msg);
    }
}
