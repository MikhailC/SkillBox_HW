namespace Hw8.Helpers
{
    [System.AttributeUsage(System.AttributeTargets.Property)]
    public class ConsoleCaptionAttribute:System.Attribute
    {

        public ConsoleCaptionAttribute(string displayName)
        {
            this.DisplayName = displayName;
        }

        public string DisplayName { get; set; }
        public bool Sortable { get; set; } = true;
    }
}