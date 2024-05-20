using Onet.Interfaces;
using CommunityToolkit.Maui.Core.Platform;

namespace Onet.Services
{
    public class KeyboardService : IKeyboardService
    {
        public async Task HideKeyboardAsync()
        {
            var allPages = Application.Current?.MainPage?.Navigation?.ModalStack.Concat(Application.Current.MainPage.Navigation.NavigationStack);

            if (allPages != null)
                foreach (var page in allPages)
                    foreach (var visualElement in GetAllVisualChildren(page))
                        if (visualElement is Entry entry)
                            await entry.HideKeyboardAsync();
        }

        private static IEnumerable<VisualElement> GetAllVisualChildren(IVisualTreeElement parent)
        {
            if (parent == null)
                yield break;

            var stack = new Stack<IVisualTreeElement>();
            stack.Push(parent);

            while (stack.Count > 0)
            {
                var element = stack.Pop();

                if (element is VisualElement visualElement)
                    yield return visualElement;

                foreach (var child in element.GetVisualChildren())
                    stack.Push(child);
            }
        }
    }
}
