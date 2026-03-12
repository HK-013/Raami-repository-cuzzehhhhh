using System.Collections.Specialized;

using GenioMVC.Models.Navigation;

namespace GenioMVC.ViewModels
{
	public abstract class EmptyFormViewModel : ViewModelBase
	{
		public IDictionary<string, object> ExtraProperties { get; private set; }
		
		public EmptyFormViewModel(UserContext userContext, bool nestedForm = false) : base(userContext)
		{
			ExtraProperties = new Dictionary<string, object>();
			InitLevels();
			// Fill the values that can already be filled (those that don't depend on the model).
			FillExtraProperties();
			NestedForm = nestedForm;
		}
		
		protected virtual void FillExtraProperties() { /* Method intentionally left empty. */ }

		public void Load(NameValueCollection qs)
		{
			Load(qs, false);
		}

		public void Load(NameValueCollection qs, bool lazyLoad)
		{
			LoadPartial(qs, lazyLoad);
		}

		protected abstract void InitLevels();

		public abstract void LoadPartial(NameValueCollection qs, bool lazyLoad = false);
	}
}
