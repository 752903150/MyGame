using System.Collections;
using System.Collections.Generic;

//CreateTime：2022/5/6 14:05:28
namespace DataCs
{
	public struct Data_Localization_Struct
	{
		public string key;
		public string ChineseSimplified;
		public string ChineseTraditional;
		public string English;

		public Data_Localization_Struct(string _key, string _ChineseSimplified, string _ChineseTraditional, string _English)
		{
			key = _key;
			ChineseSimplified = _ChineseSimplified;
			ChineseTraditional = _ChineseTraditional;
			English = _English;
		}
	}

	public static class Data_Localization
	{
		public static Dictionary<string, Data_Localization_Struct> Dic = new Dictionary<string, Data_Localization_Struct>()
		{
			{"LoadGame",new Data_Localization_Struct("LoadGame","载入游戏","載入遊戲","Load Game")},
			{"ContinueTheGame",new Data_Localization_Struct("ContinueTheGame","继续游戏","繼續遊戲","Continue Game")},
			{"NewGame",new Data_Localization_Struct("NewGame","新建游戏","新建遊戲","New Game")},
			{"Option",new Data_Localization_Struct("Option","选项","選項","Option")},
			{"ProducerList",new Data_Localization_Struct("ProducerList","制作人员表","製作人員錶","Producer List")},
			{"ExitTheGame",new Data_Localization_Struct("ExitTheGame","退出游戏","退出遊戲","Exit The Game")},
			{"Author",new Data_Localization_Struct("Author","朱凯闻","朱凱聞","Zhu Kaiwen")},
			{"Programmer",new Data_Localization_Struct("Programmer","程序员","程式師","Programmer")},
			{"Artist",new Data_Localization_Struct("Artist","美术师","美術師","Artist")},
			{"Planner",new Data_Localization_Struct("Planner","策划师","策劃師","Planner")},
			{"ReferenceGame",new Data_Localization_Struct("ReferenceGame","参考游戏","參攷遊戲","Reference game")},
			{"MountBlade",new Data_Localization_Struct("MountBlade","骑马与砍杀2","騎馬與砍殺2","Mount Blade II")},
			{"GameProducer",new Data_Localization_Struct("GameProducer","游戏制作人","遊戲製作人","Game Producer")},
			{"Exit",new Data_Localization_Struct("Exit","退出","退出","Exit")},
			{"SettingHead",new Data_Localization_Struct("SettingHead","选项","選項","Option")},
			{"Video",new Data_Localization_Struct("Video","视频","視頻","Video")},
			{"Performance",new Data_Localization_Struct("Performance","性能","效能","Performance")},
			{"AudioFrequency",new Data_Localization_Struct("AudioFrequency","音频","音訊","Audio Frequency")},
			{"Game",new Data_Localization_Struct("Game","游戏","遊戲","Game")},
			{"Key",new Data_Localization_Struct("Key","按键","按鍵","Key")},
			{"DisPlayModel",new Data_Localization_Struct("DisPlayModel","显示模式","顯示模式","Display Mode")},
			{"FullScreen",new Data_Localization_Struct("FullScreen","全屏","全屏","Full Screen")},
			{"Windowing",new Data_Localization_Struct("Windowing","窗口化","視窗化","Windowing")},
			{"ScreenResolution",new Data_Localization_Struct("ScreenResolution","屏幕分辨率","螢幕解析度","Screen Resolution")},
			{"FrameLimit",new Data_Localization_Struct("FrameLimit","帧数限制","幀數限制","Frame Limit")},
			{"DisPlayModelDes",new Data_Localization_Struct("DisPlayModelDes","选择你的显示模式，可供选择的模式有：全屏，窗口化","選擇你的顯示模式，可供選擇的模式有：全屏，視窗化","Select your display mode. The modes available are: full screen and windowing")},
			{"ScreenResolutionDes",new Data_Localization_Struct("ScreenResolutionDes","选择你的屏幕分辨率","選擇你的螢幕解析度","Choose your screen resolution")},
			{"FrameLimitDes",new Data_Localization_Struct("FrameLimitDes","将游戏帧数控制在合理的范围内","將遊戲幀數控制在合理的範圍內","Control the number of game frames within a reasonable range")},
			{"BattleScale",new Data_Localization_Struct("BattleScale","战斗规模","戰鬥規模","Battle Scale")},
			{"BattleScaleLow",new Data_Localization_Struct("BattleScaleLow","低（30）","低（30）","Low (30)")},
			{"BattleScaleMid",new Data_Localization_Struct("BattleScaleMid","中（100）","中（100）","Medium (100)")},
			{"BattleScaleHigh",new Data_Localization_Struct("BattleScaleHigh","高（200）","高（200）","Height (200)")},
			{"BattleScaleDes",new Data_Localization_Struct("BattleScaleDes","战斗规模是指在双方战斗可显示的最多实体个数","戰鬥規模是指在雙方戰鬥可顯示的最多實體個數","Battle scale refers to the maximum number of entities that can be displayed in the battle between both sides")},
			{"MasterVolume",new Data_Localization_Struct("MasterVolume","主音量","主音量","Master Volume")},
			{"BackgroundMusicVolume",new Data_Localization_Struct("BackgroundMusicVolume","背景音乐音量","背景音樂音量","Background music volume")},
			{"SoundVolume",new Data_Localization_Struct("SoundVolume","音效音量","音效音量","Sound volume")},
			{"MasterVolumeDes",new Data_Localization_Struct("MasterVolumeDes","主音量是指所有音量的大小","主音量是指所有音量的大小","The main volume refers to the size of all volumes")},
			{"BackgroundMusicVolumeDes",new Data_Localization_Struct("BackgroundMusicVolumeDes","背景音乐是指背景音量的大小","背景音樂是指背景音量的大小","Background music refers to the volume of the background")},
			{"SoundVolumeDes",new Data_Localization_Struct("SoundVolumeDes","音效音量是指音效音量的大小","音效音量是指音效音量的大小","Sound effect volume refers to the volume of sound effect")},
			{"Language",new Data_Localization_Struct("Language","语言","語言","Language")},
			{"LanguageDes",new Data_Localization_Struct("LanguageDes","控制游戏内文本的显示","控制遊戲內文字的顯示","Control the display of in-game text")},
			{"Cancel",new Data_Localization_Struct("Cancel","取消","取消","Cancel")},
			{"Complete",new Data_Localization_Struct("Complete","完成","完成","Complete")},
			{"CulturalChoice",new Data_Localization_Struct("CulturalChoice","选 择 你 角 色 的 文 化","選 擇 你 角 色 的 文 化","Choose your character's culture")},
			{"Culture",new Data_Localization_Struct("Culture","文 化","文 化","Culture")},
			{"NextItem",new Data_Localization_Struct("NextItem","下 一 项","下 一 項","Next Item")},
			{"Plain",new Data_Localization_Struct("Plain","平 原","平 原","Plain")},
			{"PlainBuff",new Data_Localization_Struct("PlainBuff","战斗中获得的声望+15%\n城堡的附属村庄产出+10%","戰鬥中獲得的聲望+15%\n城堡的附屬村莊產出+10%","Reputation gained in battle + 15% \nput of villages affiliated to the castle + 10%")},
			{"PlainDeBuff",new Data_Localization_Struct("PlainDeBuff","部队消耗增加10%","部隊消耗新增10%","Increase troop consumption by 10%")},
			{"PlainDes",new Data_Localization_Struct("PlainDes","平原人是来自西方的冒险者的后代，建立独立王国前在帝国统治下生活了几个世\n纪。随着皇权的衰落，他们演变出了组织有序的封建社由一群喜欢骑在马背上用\n长矛和骑枪作战的尚武贵族领导。","平原人是來自西方的冒險者的後代，建立獨立王國前在帝國統治下生活了幾個世\n紀。 隨著皇權的衰落，他們演變出了組織有序的封建社由一群喜歡騎在馬背上用\n長矛和騎槍作戰的尚武貴族領導。","Plain people are descendants of adventurers from the West. They lived under the rule of the Empire for several generations before the establishment of an independent kingdom. With the decline of imperial power， they evolved into an organized feudal society， led by a group of warrior nobles who liked to fight with spears and lances on horseback.")},
			{"IceSheet",new Data_Localization_Struct("IceSheet","冰 原","冰 原","Ice Sheet")},
			{"IceSheetBuff",new Data_Localization_Struct("IceSheetBuff","招募和升级步兵的费用-25%","招募和陞級步兵的費用-25%","Cost of recruiting and upgrading infantry - 25%")},
			{"IceSheetDeBuff",new Data_Localization_Struct("IceSheetDeBuff","移动速度惩罚+10%","移動速度懲罰+10%","Movement speed penalty + 10%")},
			{"IceSheetDes",new Data_Localization_Struct("IceSheetDes","冰原人是北方外来部落的后裔。当帝国扩张到他们所在的寒冷森林\n时，这些人发现自己捕猎的森林动物的奢侈毛皮很有销路。酋长们成为了\n王公，在移居到他们王国的雇佣兵的帮助下争夺着显赫地位。他们是优秀的猎人\n和旅行者，远行寻找贸易与掠夺的机会。","冰原人是北方外來部落的後裔。 當帝國擴張到他們所在的寒冷森林\n時，這些人發現自己捕獵的森林動物的奢侈毛皮很有銷路。 酋長們成為了\n王公，在移居到他們王國的雇傭兵的幫助下爭奪著顯赫地位。 他們是優秀的獵人\n和旅行者，遠行尋找貿易與掠奪的機會。","The descendants of the tribes of the north are foreigners. When the Empire expanded into their cold forests， these people found that the luxurious fur of forest animals they hunted was very marketable. The chiefs became princes， competing for prominence with the help of mercenaries who migrated to their kingdom. They are excellent hunters \n AND travelers who travel far in search of opportunities for trade and plunder.")},
			{"Plateau",new Data_Localization_Struct("Plateau","高 原","高 原","Plateau")},
			{"PlateauBuff",new Data_Localization_Struct("PlateauBuff","军队与驻军薪酬-15%","軍隊與駐軍薪酬-15%","Military and garrison salaries - 15%")},
			{"PlateauDeBuff",new Data_Localization_Struct("PlateauDeBuff","军队升级消耗+15%","軍隊陞級消耗+15%","Army upgrade cost + 15%")},
			{"PlateauDes",new Data_Localization_Struct("PlateauDes","帝国正在衰落。甚至在皇帝被谋杀之前，这个曾经统一的国家就已\n经被政治斗争所撕裂。现如今，这些阵营还在进行公开的战争。然高原人忍辱负\n重，他们潜下心来，对防御策略进行了系统研究，即驻防部队如何减缓入侵者的推进\n速度，并坚持到野战机动部队来营救他们，这有助于牵制他们的邻居。","帝國正在衰落。 甚至在皇帝被謀殺之前，這個曾經統一的國家就已\n經被政治鬥爭所撕裂。 現如今，這些陣營還在進行公開的戰爭。 然高原人忍辱負\n重，他們潜下心來，對防禦策略進行了系統研究，即駐防部隊如何減緩入侵者的推進\n速度，並堅持到野戰機動部隊來營救他們，這有助於牽制他們的鄰居。","The empire is declining. Even before the emperor was murdered， the once unified country was torn apart by political struggle. Today， these camps are still engaged in open war. However， the Highlanders endure humiliation and bear heavy burden. They dive into the heart and conduct a systematic study on the defense strategy， that is， how the garrison troops slow down the advance \n speed of the invaders and persist in the field mobile forces to rescue them， which helps contain their neighbors.")},
			{"Gobi",new Data_Localization_Struct("Gobi","戈 壁","戈 壁","Gobi")},
			{"GobiBuff",new Data_Localization_Struct("GobiBuff","贸易惩罚-10%\n军队移动速度+5%","貿易懲罰-10%\n軍隊移動速度+5%","Trade penalty - 10% \n army movement speed + 5%")},
			{"GobiDeBuff",new Data_Localization_Struct("GobiDeBuff","军队与驻军薪酬+10%","軍隊與駐軍薪酬+10%","Army and garrison salary + 10%")},
			{"GobiDes",new Data_Localization_Struct("GobiDes","戈壁人是沙漠的居民，混合了游牧人和绿洲的农民。他们以骑术和\n博学多识(尤其是医学)而闻名，这些知识来自于大陆上一些利润极高的商路。每个\n家族都以自己的血统为傲，互相蔑视，然而他们一旦被有魄力的领袖团结起来，就会\n成为南方的一支强大力量。","戈壁人是沙漠的居民，混合了遊牧人和綠洲的農民。 他們以騎術和\n博學多識（尤其是醫學）而聞名，這些知識來自於大陸上一些利潤極高的商路。 每個\n家族都以自己的血統為傲，互相蔑視，然而他們一旦被有魄力的領袖團結起來，就會\n成為南方的一支强大力量。","Gobi people are residents of the desert， a mixture of nomads and oasis farmers. They are famous for their equestrian skills and \n erudition (especially medicine)， which comes from some highly profitable business routes on the mainland. Each family is proud of its own blood and despises each other， but once they are united by bold leaders， they will \n become a powerful force in the south.")},
			{"Grassland",new Data_Localization_Struct("Grassland","草 原","草 原","Grassland")},
			{"GrasslandBuff",new Data_Localization_Struct("GrasslandBuff","升级骑兵的费用-15%\n统治者拥有的村庄：马匹，骡子，牛和羊产出+10%","陞級騎兵的費用-15%\n統治者擁有的村莊：馬匹，騾子，牛和羊產出+10%","Cost of upgrading Cavalry - 15% \nproduction of villages owned by rulers: horses， mules， cattle and sheep + 10%")},
			{"GrasslandDeBuff",new Data_Localization_Struct("GrasslandDeBuff","城镇税收-20%\n工坊收入-10%","城鎮稅收-20%\n工坊收入-10%","Urban Tax - 20% \n workshop income - 10%")},
			{"GrasslandDes",new Data_Localization_Struct("GrasslandDes","虽然这个草原部落联盟曾经过着游牧的生活，但他们现在已经定居在帝国的东部边\n境，并逐渐过渡到拥有固定城镇中心的农业社会。尽管如此，他们仍然保留着许多游\n牧生活的旧习，包括对马匹的喜爱。他们精于骑射，可以在打击敌人时保持安全距离。","雖然這個草原部落聯盟曾經過著遊牧的生活，但他們現在已經定居在帝國的東部邊\n境，並逐漸過渡到擁有固定城鎮中心的農業社會。 儘管如此，他們仍然保留著許多遊\n牧生活的舊習，包括對馬匹的喜愛。 他們精於騎射，可以在打擊敵人時保持安全距離。","Although this grassland tribal alliance once lived a nomadic life， they have now settled in the eastern border of the Empire and gradually transitioned to an agricultural society with fixed urban centers. Nevertheless， they still retain many old habits of nomadic life， including their love for horses. They are good at riding and shooting and can keep a safe distance when attacking the enemy.")},
			{"Forest",new Data_Localization_Struct("Forest","森 林","森 林","Forest")},
			{"ForestBuff",new Data_Localization_Struct("ForestBuff","速度惩罚-10%\n速度奖励+10%\n视野范围+10%","速度懲罰-10%\n速度獎勵+10%\n視野範圍+10%","Speed penalty - 10% \n speed reward + 10% \n field of view + 10%")},
			{"ForestDeBuff",new Data_Localization_Struct("ForestDeBuff","工程建设速度-10%","工程建設速度-10%","Construction speed - 10%")},
			{"ForestDes",new Data_Localization_Struct("ForestDes","对森林人而言，昔日时光依然历历在目，那时茂密的森林遍布大陆北\n部，帝国与它的城市尚未侵犯他们的圣地。这些勇猛的战士仍然忠于传统，作战前他\n们会在脸上涂抹战纹，就连贵族们也更偏好使用致命的巨斧和双手剑徒步作战。","對森林人而言，昔日時光依然歷歷在目，那時茂密的森林遍佈大陸北\n部，帝國與它的都市尚未侵犯他們的聖地。 這些勇猛的戰士仍然忠於傳統，作戰前他\n們會在臉上塗抹戰紋，就連貴族們也更偏好使用致命的巨斧和雙手劍徒步作戰。","For the foresters， the old days are still vivid. At that time， dense forests were all over the north of the continent， and the Empire and its cities had not invaded their holy land. These brave soldiers are still loyal to the tradition. Before fighting， they will smear war marks on their faces. Even the nobles prefer to fight on foot with deadly axes and two handed swords.")},
		};
		public static string key_LoadGame = "LoadGame";
		public static string key_ContinueTheGame = "ContinueTheGame";
		public static string key_NewGame = "NewGame";
		public static string key_Option = "Option";
		public static string key_ProducerList = "ProducerList";
		public static string key_ExitTheGame = "ExitTheGame";
		public static string key_Author = "Author";
		public static string key_Programmer = "Programmer";
		public static string key_Artist = "Artist";
		public static string key_Planner = "Planner";
		public static string key_ReferenceGame = "ReferenceGame";
		public static string key_MountBlade = "MountBlade";
		public static string key_GameProducer = "GameProducer";
		public static string key_Exit = "Exit";
		public static string key_SettingHead = "SettingHead";
		public static string key_Video = "Video";
		public static string key_Performance = "Performance";
		public static string key_AudioFrequency = "AudioFrequency";
		public static string key_Game = "Game";
		public static string key_Key = "Key";
		public static string key_DisPlayModel = "DisPlayModel";
		public static string key_FullScreen = "FullScreen";
		public static string key_Windowing = "Windowing";
		public static string key_ScreenResolution = "ScreenResolution";
		public static string key_FrameLimit = "FrameLimit";
		public static string key_DisPlayModelDes = "DisPlayModelDes";
		public static string key_ScreenResolutionDes = "ScreenResolutionDes";
		public static string key_FrameLimitDes = "FrameLimitDes";
		public static string key_BattleScale = "BattleScale";
		public static string key_BattleScaleLow = "BattleScaleLow";
		public static string key_BattleScaleMid = "BattleScaleMid";
		public static string key_BattleScaleHigh = "BattleScaleHigh";
		public static string key_BattleScaleDes = "BattleScaleDes";
		public static string key_MasterVolume = "MasterVolume";
		public static string key_BackgroundMusicVolume = "BackgroundMusicVolume";
		public static string key_SoundVolume = "SoundVolume";
		public static string key_MasterVolumeDes = "MasterVolumeDes";
		public static string key_BackgroundMusicVolumeDes = "BackgroundMusicVolumeDes";
		public static string key_SoundVolumeDes = "SoundVolumeDes";
		public static string key_Language = "Language";
		public static string key_LanguageDes = "LanguageDes";
		public static string key_Cancel = "Cancel";
		public static string key_Complete = "Complete";
		public static string key_CulturalChoice = "CulturalChoice";
		public static string key_Culture = "Culture";
		public static string key_NextItem = "NextItem";
		public static string key_Plain = "Plain";
		public static string key_PlainBuff = "PlainBuff";
		public static string key_PlainDeBuff = "PlainDeBuff";
		public static string key_PlainDes = "PlainDes";
		public static string key_IceSheet = "IceSheet";
		public static string key_IceSheetBuff = "IceSheetBuff";
		public static string key_IceSheetDeBuff = "IceSheetDeBuff";
		public static string key_IceSheetDes = "IceSheetDes";
		public static string key_Plateau = "Plateau";
		public static string key_PlateauBuff = "PlateauBuff";
		public static string key_PlateauDeBuff = "PlateauDeBuff";
		public static string key_PlateauDes = "PlateauDes";
		public static string key_Gobi = "Gobi";
		public static string key_GobiBuff = "GobiBuff";
		public static string key_GobiDeBuff = "GobiDeBuff";
		public static string key_GobiDes = "GobiDes";
		public static string key_Grassland = "Grassland";
		public static string key_GrasslandBuff = "GrasslandBuff";
		public static string key_GrasslandDeBuff = "GrasslandDeBuff";
		public static string key_GrasslandDes = "GrasslandDes";
		public static string key_Forest = "Forest";
		public static string key_ForestBuff = "ForestBuff";
		public static string key_ForestDeBuff = "ForestDeBuff";
		public static string key_ForestDes = "ForestDes";
	}
}

