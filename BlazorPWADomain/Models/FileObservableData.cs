using System.ComponentModel;

namespace BlazorPWADomain.Models
{
    public class FileObservable : INotifyPropertyChanged
    {
        public FileObservable(string name, string extension, byte[] bytes)
        {
            Name = name;
            Extension = extension;
            Bytes = bytes;
            _id = Guid.NewGuid();
        }
        public Guid Id
        {
            get { return _id; }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("_name");
            }
        }
        public string Extension
        {
            get { return _extension; }
            set
            {
                _extension = value;
                NotifyPropertyChanged("_extension");
            }
        }
        public byte[] Bytes
        {
            get { return _bytes; }
            set
            {
                _bytes = value;
                NotifyPropertyChanged("_bytes");
            }
        }
        public int PreviewHeight
        {
            get { return _previewHeight; }
            set
            {
                _previewHeight = value;
                NotifyPropertyChanged("_previewHeight");
            }
        }
        public int PreviewWidth 
        {
            get { return _previewWidth; }
            set
            {
                _previewWidth = value;
                NotifyPropertyChanged("_previewWidth");
            }
        }


        private Guid _id;
        private string _name;
        private string _extension;
        private byte[] _bytes;
        private int _previewHeight = 0;
        private int _previewWidth = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        ///     Converts byte array Bytes to base64 imgage url
        /// </summary>
        /// <returns>Base64 image url</returns>
        public string GetImageUrlFromBytes()
        {
            if (Bytes == null)
                return "";

            var base64 = Convert.ToBase64String(Bytes);
            return string.Format("data:image/gif;base64,{0}", base64);
        }
    }
}