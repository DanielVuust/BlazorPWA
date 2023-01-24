using System.ComponentModel;

namespace BlazorPWADomain
{
    public class FileObservableData : INotifyPropertyChanged
    {
        public FileObservableData(string name, string extension, byte[] bytes)
        {
            this.Name = name;
            this.Extension = extension;
            this.Bytes = bytes;
            this.Id = Guid.NewGuid();
        }
        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                this.NotifyPropertyChanged("_id");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                this.NotifyPropertyChanged("_name");
            }
        }
        public string Extension
        {
            get { return _extension; }
            set
            {
                _extension = value;
                this.NotifyPropertyChanged("_extension");
            }
        }
        public byte[] Bytes
        {
            get { return _bytes; }
            set
            {
                _bytes = value;
                this.NotifyPropertyChanged("_bytes");
            }
        }

        private Guid _id;
        private string _name;
        private string _extension;
        private byte[] _bytes;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string ConvertToByte64()
        {
            if (Bytes == null)
                return "";

            var base64 = Convert.ToBase64String(this.Bytes);
            return String.Format("data:image/gif;base64,{0}", base64);
        }
    }
}