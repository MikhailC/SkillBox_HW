using System.Reflection;
using System.Reflection.Metadata;

namespace Hw8
{
    public interface IMenuCommand
    {
        string Title { get;  }
        void Execute();
    }
}