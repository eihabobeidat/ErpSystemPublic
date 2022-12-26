using ErpSystem.core.DTO;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.infra.Services
{
    public class SliderService : ISliderService
    {
        private readonly ISliderRepository sliderRepository;
        public SliderService(ISliderRepository sliderRepository)
        {
            this.sliderRepository = sliderRepository;
        }
        public List<SliderImageDTO> GetImage()
        {
            return sliderRepository.GetImage();
        }

        public bool newSlider(string[] fill)
        {
            return sliderRepository.newSlider(fill);
        }
        public List<SliderImageDTO> GetAllImage()
        {
            return sliderRepository.GetAllImage();
        }


    }
}
