using Game;
using Patchwork;
using Onyx;
using UnityEngine;
using Game.GameData;
using Game.UI;

namespace lukeee_g_DisableScreenShake
{
    [ModifiesType]
    public class Lukeee_gCompanyIntroductionManager : Game.UI.CompanyIntroductionManager
    {

        [ModifiesMember("Start")]
        public void Start()
        {
            // Set m_skipIntro to true to skip logos
            this.m_skipIntro = true;
            Time.timeScale = 1f;
            this.ObsidianLogoTexture.alpha = 0f;
            this.PublisherTexture.alpha = 0f;
            GameUtilities.CreateGlobalPrefabObject();
            base.StartCoroutine(this.IntroCoroutine());
        }
    }
}
