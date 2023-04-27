using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResSettings : MonoBehaviour
{
    public Dropdown ResDropdown;
    public Toggle isFullScreen;
     Resolution[] resolutions;
    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;
        isFullScreen.isOn = Screen.fullScreen;

        for (int i =0; i< resolutions.Length; i++){
            string resString = resolutions[i].width.ToString() + "x" + resolutions[i].height.ToString();
            ResDropdown.options.Add(new Dropdown.OptionData(resString));

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                    ResDropdown.value = i;
            }
        }
    }

    public void SetResolution()
    {
        Screen.SetResolution(resolutions[ResDropdown.value].width,resolutions[ResDropdown.value].height, isFullScreen.isOn);
    }
}
