using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Repository
{
    public interface ISliderRepository
    {
        public List<SliderImageDTO> GetImage();
        public bool newSlider(string[] fill);
        public List<SliderImageDTO> GetAllImage();

    }
}
