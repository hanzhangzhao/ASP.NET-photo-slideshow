using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace part2
{
    public partial class slideshow : System.Web.UI.Page
    {
        private IReadOnlyList<Photo> _photos;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _photos = _photos ?? Conn.GetAllPhotos();
            }
            catch (Exception)
            {
                _photos = new List<Photo>();
            }
        }

        private Photo GetCurrPhoto() => _photos.FirstOrDefault(p => p.Url.Equals(PhotoDisplay.ImageUrl, StringComparison.InvariantCultureIgnoreCase));

        private void SetCurrPhoto(Photo photo)
        {
            if (photo == null)
                return;

            PhotoDisplay.ImageUrl = photo.Url;
            CaptionLabel.Text = photo.Description;
            Label2.Text = photo.Name;
        }


        private Photo GetPrevPhoto()
        {
            var currPhoto = GetCurrPhoto();
            if (currPhoto == null)
                return null;

            var prevId = currPhoto.Id == 1 ? 20 : currPhoto.Id - 1;
            return _photos.FirstOrDefault(p => p.Id == prevId);
        }

        private Photo GetNextPhoto()
        {
            var currPhoto = GetCurrPhoto();
            if (currPhoto == null)
                return null;

            var nextId = currPhoto.Id == 20 ? 1 : currPhoto.Id + 1;
            return _photos.FirstOrDefault(p => p.Id == nextId);
        }

        private void SetRandomPhoto()
        {
            var currPhoto = GetCurrPhoto();
            var nextId = currPhoto?.Id;
            if (nextId == null)
                return;

            while (nextId == currPhoto.Id)
            {
                var rnd = new Random();
                nextId = rnd.Next(1, 21); 
            }

            var nextPhoto = _photos.FirstOrDefault(p => p.Id == nextId);
            SetCurrPhoto(nextPhoto);
        }

        protected void ImagePrev_Click(object sender, ImageClickEventArgs e)
        {
            SetCurrPhoto(GetPrevPhoto());
        }

        protected void ForwardBackwardButton_Click(object sender, EventArgs e)
        {
            NextPhoto();
        }

        private void NextPhoto()
        {
            if (!RamdomMode())
                SetCurrPhoto(GetNextPhoto());
            else
                SetRandomPhoto();
        }

        private bool RamdomMode() => RandomOn.Value == "true";

        protected void StartStopButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Text == "Start")
            {
                button.Text = "Stop";
                this.PhotoTimer.Enabled = true;
            }
            else
            {
                button.Text = "Start";
                this.PhotoTimer.Enabled = false;
            }
        }

        protected void SequentialRandomButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Text == "Random")
            {
                button.Text = "Sequential";
                RandomOn.Value = "true";
                this.forwardBtn.Enabled = false;
                this.backwardBtn.Enabled = false;
            }
            else
            {
                button.Text = "Random";
                RandomOn.Value = "false";
                this.forwardBtn.Enabled = true;
                this.backwardBtn.Enabled = true;
            }
        }

        protected void BackwardButton_Click(object sender, EventArgs e)
        {
            if (!RamdomMode())
                SetCurrPhoto(GetPrevPhoto());
            else
                SetRandomPhoto();
        }

        protected void ForwardButton_Click(object sender, EventArgs e)
        {
            NextPhoto();
        }

        protected void PhotoTimer_Tick(object sender, EventArgs e)
        {
            NextPhoto();
        }

    }
}





