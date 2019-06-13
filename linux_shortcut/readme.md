## Linux 桌面快捷方式

参考：
* desktop文件入门 <br>
  https://deepin.lolimay.cn/booklet/desktop.html
* Linux 桌面快捷方式 Desktop Entry 详解 <br>
  http://blog.chinaunix.net/uid-20332519-id-3015914.html
* Desktop Entry Specification 官网 <br>
  https://specifications.freedesktop.org/desktop-entry-spec/desktop-entry-spec-latest.html

#### Part 1 —— Linux 是如何管理应用程序列表的

##### 1. 桌面系统的核心交互入口 applications 列表
* 开发者的习惯 <br>
  通过源码编译安装、解压二进制等形式安装软件，此时将无法在 applications 列表中被查找。
  （事实上这种情况我们往往是创建软连接到 /usr/bin 目录中。）
* 桌面系统用户习惯 <br>
  在 applications 列表中查找应用程序，点击启动。

##### 2. 添加应用程序到 applications 列表
* /usr/share/applications/ <br>
  Linux 通过这个目录下的配置文件来管理应用程序。（以 *.desktop 为后缀名的文件）
* 创建自己的 desktop 文件 <br>
  在该目录下复制一个 desktop 文件即可，重命名并且打开这个文件进行编辑。
* 将 desktop 文件放置于 /usr/share/applications/ 目录
* 将 /usr/share/applications 目录下的快捷方式 copy 至 ~/Desktop 即可。

##### 3. desktop 文件配置节点的意义

第一部分
* \[Desktop Entry] <br>
  文件头，表示桌面入口。 必填。
* Version <br>
  desktop 文件标准的版本，请参考 ~/examples.desktop 文件。 必填。
* Type <br>
  分类，Application 或 Link。 必填。

第二部分
* Name <br>
  应用程序名称，根据当前系统语言匹配显示，优先匹配更细化的语言标识名称。 必填。
* Comment <br>
  鼠标经过上面时的提示名称，根据当前系统语言匹配显示，优先匹配更细化的语言标识名称。（与 Name 一一对应，可以为空）
* GenericName <br>
  应用程序通用名称，他会显示在搜索结果以及非搜索结果中。 (可以没有)
* Keywords <br>
  与 GenericName 一一对应。 (可以没有)
* Icon <br>
  显示在菜单项中的图标。（例如：Icon=/home/zhiheng/baidu.png） 可以为空。

第三部分 文件夹的快捷方式
* URL <br>
  文件夹路径。 （例如：URL=file:///usr/share/example-content/）
* X-Ubuntu-Gettext-Domain <br>
  Session 定义。 （例如：X-Ubuntu-Gettext-Domain=example-content）

第四部分 应用程序的快捷方式
* Exec <br>
  应用程序启动的指令，可以带上参数运行，实际上这与在终端的启动指令是一样的。 必填。
* Terminal <br>
  表明 Exec 是否需要在终端中运行。 一般设置为 false。 （可选）
* Categories <br>
  表明应用程序在菜单中显示的类别，关于类别的定义参见Desktop Specification Menu的具体定义。（可选）
* MimeType <br>
  熟悉 web 开发的人员应当十分熟悉，这是表明映射。 （可选）
* StartupNotify <br>
  启动时是否通知。 （可选）

<br>

##### Part 2 —— 快捷方式参考模板
* Application 类型
    * 请参考 /usr/share/applications/firefox.desktop
* Link 类型
    * ubuntu 的 ~/ 目录下 examples.desktop，即官方提供的快捷方式模板！

###### 模板1 （APP）： FireFox 浏览器 Desktop 文件
```
[Desktop Entry]
Version=1.0
Name=Firefox Web Browser
Name[ar]=متصفح الويب فَيَرفُكْس
Name[ast]=Restolador web Firefox
Name[bn]=ফায়ারফক্স ওয়েব ব্রাউজার
Name[ca]=Navegador web Firefox
Name[cs]=Firefox Webový prohlížeč
Name[da]=Firefox - internetbrowser
Name[el]=Περιηγητής Firefox
Name[es]=Navegador web Firefox
Name[et]=Firefoxi veebibrauser
Name[fa]=مرورگر اینترنتی Firefox
Name[fi]=Firefox-selain
Name[fr]=Navigateur Web Firefox
Name[gl]=Navegador web Firefox
Name[he]=דפדפן האינטרנט Firefox
Name[hr]=Firefox web preglednik
Name[hu]=Firefox webböngésző
Name[it]=Firefox Browser Web
Name[ja]=Firefox ウェブ・ブラウザ
Name[ko]=Firefox 웹 브라우저
Name[ku]=Geroka torê Firefox
Name[lt]=Firefox interneto naršyklė
Name[nb]=Firefox Nettleser
Name[nl]=Firefox webbrowser
Name[nn]=Firefox Nettlesar
Name[no]=Firefox Nettleser
Name[pl]=Przeglądarka WWW Firefox
Name[pt]=Firefox Navegador Web
Name[pt_BR]=Navegador Web Firefox
Name[ro]=Firefox – Navigator Internet
Name[ru]=Веб-браузер Firefox
Name[sk]=Firefox - internetový prehliadač
Name[sl]=Firefox spletni brskalnik
Name[sv]=Firefox webbläsare
Name[tr]=Firefox Web Tarayıcısı
Name[ug]=Firefox توركۆرگۈ
Name[uk]=Веб-браузер Firefox
Name[vi]=Trình duyệt web Firefox
Name[zh_CN]=Firefox 网络浏览器
Name[zh_TW]=Firefox 網路瀏覽器
Comment=Browse the World Wide Web
Comment[ar]=تصفح الشبكة العنكبوتية العالمية
Comment[ast]=Restola pela Rede
Comment[bn]=ইন্টারনেট ব্রাউজ করুন
Comment[ca]=Navegueu per la web
Comment[cs]=Prohlížení stránek World Wide Webu
Comment[da]=Surf på internettet
Comment[de]=Im Internet surfen
Comment[el]=Μπορείτε να περιηγηθείτε στο διαδίκτυο (Web)
Comment[es]=Navegue por la web
Comment[et]=Lehitse veebi
Comment[fa]=صفحات شبکه جهانی اینترنت را مرور نمایید
Comment[fi]=Selaa Internetin WWW-sivuja
Comment[fr]=Naviguer sur le Web
Comment[gl]=Navegar pola rede
Comment[he]=גלישה ברחבי האינטרנט
Comment[hr]=Pretražite web
Comment[hu]=A világháló böngészése
Comment[it]=Esplora il web
Comment[ja]=ウェブを閲覧します
Comment[ko]=웹을 돌아 다닙니다
Comment[ku]=Li torê bigere
Comment[lt]=Naršykite internete
Comment[nb]=Surf på nettet
Comment[nl]=Verken het internet
Comment[nn]=Surf på nettet
Comment[no]=Surf på nettet
Comment[pl]=Przeglądanie stron WWW 
Comment[pt]=Navegue na Internet
Comment[pt_BR]=Navegue na Internet
Comment[ro]=Navigați pe Internet
Comment[ru]=Доступ в Интернет
Comment[sk]=Prehliadanie internetu
Comment[sl]=Brskajte po spletu
Comment[sv]=Surfa på webben
Comment[tr]=İnternet'te Gezinin
Comment[ug]=دۇنيادىكى توربەتلەرنى كۆرگىلى بولىدۇ
Comment[uk]=Перегляд сторінок Інтернету
Comment[vi]=Để duyệt các trang web
Comment[zh_CN]=浏览互联网
Comment[zh_TW]=瀏覽網際網路
GenericName=Web Browser
GenericName[ar]=متصفح ويب
GenericName[ast]=Restolador Web
GenericName[bn]=ওয়েব ব্রাউজার
GenericName[ca]=Navegador web
GenericName[cs]=Webový prohlížeč
GenericName[da]=Webbrowser
GenericName[el]=Περιηγητής διαδικτύου
GenericName[es]=Navegador web
GenericName[et]=Veebibrauser
GenericName[fa]=مرورگر اینترنتی
GenericName[fi]=WWW-selain
GenericName[fr]=Navigateur Web
GenericName[gl]=Navegador Web
GenericName[he]=דפדפן אינטרנט
GenericName[hr]=Web preglednik
GenericName[hu]=Webböngésző
GenericName[it]=Browser web
GenericName[ja]=ウェブ・ブラウザ
GenericName[ko]=웹 브라우저
GenericName[ku]=Geroka torê
GenericName[lt]=Interneto naršyklė
GenericName[nb]=Nettleser
GenericName[nl]=Webbrowser
GenericName[nn]=Nettlesar
GenericName[no]=Nettleser
GenericName[pl]=Przeglądarka WWW
GenericName[pt]=Navegador Web
GenericName[pt_BR]=Navegador Web
GenericName[ro]=Navigator Internet
GenericName[ru]=Веб-браузер
GenericName[sk]=Internetový prehliadač
GenericName[sl]=Spletni brskalnik
GenericName[sv]=Webbläsare
GenericName[tr]=Web Tarayıcı
GenericName[ug]=توركۆرگۈ
GenericName[uk]=Веб-браузер
GenericName[vi]=Trình duyệt Web
GenericName[zh_CN]=网络浏览器
GenericName[zh_TW]=網路瀏覽器
Keywords=Internet;WWW;Browser;Web;Explorer
Keywords[ar]=انترنت;إنترنت;متصفح;ويب;وب
Keywords[ast]=Internet;WWW;Restolador;Web;Esplorador
Keywords[ca]=Internet;WWW;Navegador;Web;Explorador;Explorer
Keywords[cs]=Internet;WWW;Prohlížeč;Web;Explorer
Keywords[da]=Internet;Internettet;WWW;Browser;Browse;Web;Surf;Nettet
Keywords[de]=Internet;WWW;Browser;Web;Explorer;Webseite;Site;surfen;online;browsen
Keywords[el]=Internet;WWW;Browser;Web;Explorer;Διαδίκτυο;Περιηγητής;Firefox;Φιρεφοχ;Ιντερνετ
Keywords[es]=Explorador;Internet;WWW
Keywords[fi]=Internet;WWW;Browser;Web;Explorer;selain;Internet-selain;internetselain;verkkoselain;netti;surffaa
Keywords[fr]=Internet;WWW;Browser;Web;Explorer;Fureteur;Surfer;Navigateur
Keywords[he]=דפדפן;אינטרנט;רשת;אתרים;אתר;פיירפוקס;מוזילה;
Keywords[hr]=Internet;WWW;preglednik;Web
Keywords[hu]=Internet;WWW;Böngésző;Web;Háló;Net;Explorer
Keywords[it]=Internet;WWW;Browser;Web;Navigatore
Keywords[is]=Internet;WWW;Vafri;Vefur;Netvafri;Flakk
Keywords[ja]=Internet;WWW;Web;インターネット;ブラウザ;ウェブ;エクスプローラ
Keywords[nb]=Internett;WWW;Nettleser;Explorer;Web;Browser;Nettside
Keywords[nl]=Internet;WWW;Browser;Web;Explorer;Verkenner;Website;Surfen;Online 
Keywords[pt]=Internet;WWW;Browser;Web;Explorador;Navegador
Keywords[pt_BR]=Internet;WWW;Browser;Web;Explorador;Navegador
Keywords[ru]=Internet;WWW;Browser;Web;Explorer;интернет;браузер;веб;файрфокс;огнелис
Keywords[sk]=Internet;WWW;Prehliadač;Web;Explorer
Keywords[sl]=Internet;WWW;Browser;Web;Explorer;Brskalnik;Splet
Keywords[tr]=İnternet;WWW;Tarayıcı;Web;Gezgin;Web sitesi;Site;sörf;çevrimiçi;tara
Keywords[uk]=Internet;WWW;Browser;Web;Explorer;Інтернет;мережа;переглядач;оглядач;браузер;веб;файрфокс;вогнелис;перегляд
Keywords[vi]=Internet;WWW;Browser;Web;Explorer;Trình duyệt;Trang web
Keywords[zh_CN]=Internet;WWW;Browser;Web;Explorer;网页;浏览;上网;火狐;Firefox;ff;互联网;网站;
Keywords[zh_TW]=Internet;WWW;Browser;Web;Explorer;網際網路;網路;瀏覽器;上網;網頁;火狐
Exec=firefox %u
Terminal=false
X-MultipleArgs=false
Type=Application
Icon=firefox
Categories=GNOME;GTK;Network;WebBrowser;
MimeType=text/html;text/xml;application/xhtml+xml;application/xml;application/rss+xml;application/rdf+xml;image/gif;image/jpeg;image/png;x-scheme-handler/http;x-scheme-handler/https;x-scheme-handler/ftp;x-scheme-handler/chrome;video/webm;application/x-xpinstall;
StartupNotify=true
Actions=NewWindow;NewPrivateWindow;

[Desktop Action NewWindow]
Name=Open a New Window
Name[ar]=افتح نافذة جديدة
Name[ast]=Abrir una ventana nueva
Name[bn]=Abrir una ventana nueva
Name[ca]=Obre una finestra nova
Name[cs]=Otevřít nové okno
Name[da]=Åbn et nyt vindue
Name[de]=Ein neues Fenster öffnen
Name[el]=Άνοιγμα νέου παραθύρου
Name[es]=Abrir una ventana nueva
Name[fi]=Avaa uusi ikkuna
Name[fr]=Ouvrir une nouvelle fenêtre
Name[gl]=Abrir unha nova xanela
Name[he]=פתיחת חלון חדש
Name[hr]=Otvori novi prozor
Name[hu]=Új ablak nyitása
Name[it]=Apri una nuova finestra
Name[ja]=新しいウィンドウを開く
Name[ko]=새 창 열기
Name[ku]=Paceyeke nû veke
Name[lt]=Atverti naują langą
Name[nb]=Åpne et nytt vindu
Name[nl]=Nieuw venster openen
Name[pt]=Abrir nova janela
Name[pt_BR]=Abrir nova janela
Name[ro]=Deschide o fereastră nouă
Name[ru]=Новое окно
Name[sk]=Otvoriť nové okno
Name[sl]=Odpri novo okno
Name[sv]=Öppna ett nytt fönster
Name[tr]=Yeni pencere aç 
Name[ug]=يېڭى كۆزنەك ئېچىش
Name[uk]=Відкрити нове вікно
Name[vi]=Mở cửa sổ mới
Name[zh_CN]=新建窗口
Name[zh_TW]=開啟新視窗
Exec=firefox -new-window
OnlyShowIn=Unity;

[Desktop Action NewPrivateWindow]
Name=Open a New Private Window
Name[ar]=افتح نافذة جديدة للتصفح الخاص
Name[ca]=Obre una finestra nova en mode d'incògnit
Name[de]=Ein neues privates Fenster öffnen
Name[es]=Abrir una ventana privada nueva
Name[fi]=Avaa uusi yksityinen ikkuna
Name[fr]=Ouvrir une nouvelle fenêtre de navigation privée
Name[he]=פתיחת חלון גלישה פרטית חדש
Name[hu]=Új privát ablak nyitása
Name[it]=Apri una nuova finestra anonima
Name[nb]=Åpne et nytt privat vindu
Name[ru]=Новое приватное окно
Name[sl]=Odpri novo okno zasebnega brskanja
Name[tr]=Yeni bir pencere aç
Name[uk]=Відкрити нове вікно у потайливому режимі
Name[zh_TW]=開啟新隱私瀏覽視窗
Exec=firefox -private-window
OnlyShowIn=Unity;
```

###### 模板1 （文件夹链接）： ubuntu 的 ~/examples.desktop
```
[Desktop Entry]
Version=1.0
Type=Link
Name=Examples
Name[aa]=Ceelallo
Name[ace]=Contoh
Name[af]=Voorbeelde
Name[am]=ምሳሌዎች
Name[an]=Exemplos
Name[ar]=أمثلة
Name[ast]=Exemplos
Name[az]=Nümunələr
Name[be]=Прыклады
Name[bg]=Примери
Name[bn]=উদাহরণ
Name[br]=Skouerioù
Name[bs]=Primjeri
Name[ca]=Exemples
Name[ca@valencia]=Exemples
Name[ckb]=نمونه‌كان
Name[cs]=Ukázky
Name[csb]=Przëmiôrë
Name[cy]=Enghreifftiau
Name[da]=Eksempler
Name[de]=Beispiele
Name[dv]=މިސާލުތަށް
Name[el]=Παραδείγματα
Name[en_AU]=Examples
Name[en_CA]=Examples
Name[en_GB]=Examples
Name[eo]=Ekzemploj
Name[es]=Ejemplos
Name[et]=Näidised
Name[eu]=Adibideak
Name[fa]=نمونه‌ها
Name[fi]=Esimerkkejä
Name[fil]=Mga halimbawa
Name[fo]=Dømir
Name[fr]=Exemples
Name[fur]=Esemplis
Name[fy]=Foarbylden
Name[ga]=Samplaí
Name[gd]=Buill-eisimpleir
Name[gl]=Exemplos
Name[gu]=દૃષ્ટાન્તો
Name[gv]=Sampleyryn
Name[he]=דוגמאות
Name[hi]=उदाहरण
Name[hr]=Primjeri
Name[ht]=Egzanp
Name[hu]=Minták
Name[hy]=Օրինակներ
Name[id]=Contoh
Name[is]=Sýnishorn
Name[it]=Esempi
Name[ja]=サンプル
Name[ka]=ნიმუშები
Name[kk]=Мысалдар
Name[kl]=Assersuutit
Name[km]=ឧទាហរណ៍
Name[kn]=ಉದಾಹರಣೆಗಳು
Name[ko]=예시
Name[ku]=Mînak
Name[kw]=Ensamplow
Name[ky]=Мисалдар
Name[lb]=Beispiller
Name[lt]=Pavyzdžių failai
Name[lv]=Paraugi
Name[mg]=Ohatra
Name[mhr]=Пример-влак
Name[mi]=Tauira
Name[mk]=Примери
Name[ml]=ഉദാഹരണങ്ങള്‍
Name[mr]=उदाहरणे
Name[ms]=Contoh-contoh
Name[my]=ဥပမာများ
Name[nb]=Eksempler
Name[nds]=Bispelen
Name[ne]=उदाहरणहरू
Name[nl]=Voorbeeld-bestanden
Name[nn]=Døme
Name[nso]=Mehlala
Name[oc]=Exemples
Name[pa]=ਉਦਾਹਰਨਾਂ
Name[pl]=Przykłady
Name[pt]=Exemplos
Name[pt_BR]=Exemplos
Name[ro]=Exemple
Name[ru]=Примеры
Name[sc]=Esempiusu
Name[sco]=Examples
Name[sd]=مثالون
Name[se]=Ovdamearkkat
Name[shn]=တူဝ်ယၢင်ႇ
Name[si]=නිදසුන්
Name[sk]=Príklady
Name[sl]=Zgledi
Name[sml]=Saga Saupama
Name[sn]=Miyenzaniso
Name[sq]=Shembujt
Name[sr]=Примери
Name[sv]=Exempel
Name[sw]=Mifano
Name[szl]=Bajszpile
Name[ta]=உதாரணங்கள்
Name[ta_LK]=உதாரணங்கள்
Name[te]=ఉదాహరణలు
Name[tg]=Намунаҳо
Name[th]=ตัวอย่าง
Name[tr]=Örnekler
Name[tt]=Мисаллар
Name[ug]=مىساللار
Name[uk]=Приклади
Name[ur]=مثالیں
Name[uz]=Намуналар
Name[vec]=Esempi
Name[vi]=Mẫu ví dụ
Name[wae]=Bischbil
Name[zh_CN]=示例
Name[zh_HK]=範例
Name[zh_TW]=範例
Comment=Example content for Ubuntu
Comment[aa]=Ubuntuh addattinoh ceelallo
Comment[ace]=Contoh aso ke Ubuntu
Comment[af]=Voorbeeld inhoud vir Ubuntu
Comment[am]=ዝርዝር ምሳሌዎች ለ ኡቡንቱ
Comment[an]=Conteniu d'exemplo ta Ubuntu
Comment[ar]=أمثلة محتوى لأوبونتو
Comment[ast]=Conteníu del exemplu pa Ubuntu
Comment[az]=Ubuntu üçün nümunə material
Comment[be]=Узоры дакументаў для Ubuntu
Comment[bg]=Примерно съдържание за Ubuntu
Comment[bn]=উবুন্টু সংক্রান্ত নমুনা তথ্য
Comment[br]=Skouerenn endalc'had evit Ubuntu
Comment[bs]=Primjer sadrzaja za Ubuntu
Comment[ca]=Continguts d'exemple per a l'Ubuntu
Comment[ca@valencia]=Continguts d'exemple per a l'Ubuntu
Comment[ckb]=نموونەی ناوەڕۆکێک بۆ ئوبوونتو
Comment[cs]=Ukázkový obsah pro Ubuntu
Comment[csb]=Przëmiôrowô zamkłosc dlô Ubuntu
Comment[cy]=Cynnwys enghraifft ar gyfer  Ubuntu
Comment[da]=Eksempel indhold til Ubuntu
Comment[de]=Beispielinhalt für Ubuntu
Comment[dv]=އުބުންޓު އާއި އެކަށޭނަ މިސާލުތައް
Comment[el]=Παραδείγματα περιεχομένου για το Ubuntu
Comment[en_AU]=Example content for Ubuntu
Comment[en_CA]=Example content for Ubuntu
Comment[en_GB]=Example content for Ubuntu
Comment[eo]=Ekzempla enhavo por Ubuntu
Comment[es]=Contenido de ejemplo para Ubuntu
Comment[et]=Ubuntu näidisfailid
Comment[eu]=Adibidezko edukia Ubunturako
Comment[fa]=محتویات نمونه برای اوبونتو
Comment[fi]=Esimerkkisisältöjä Ubuntulle
Comment[fil]=Halimbawang laman para sa Ubuntu
Comment[fo]=Dømis innihald fyri Ubuntu
Comment[fr]=Contenu d'exemple pour Ubuntu
Comment[fur]=Contignûts di esempli par Ubuntu
Comment[fy]=Foarbyld fan ynhâld foar Ubuntu
Comment[ga]=Inneachar samplach do Ubuntu
Comment[gd]=Eisimpleir de shusbaint airson Ubuntu
Comment[gl]=Contido do exemplo para Ubuntu
Comment[gu]=Ubuntu માટે ઉદાહરણ સૂચી
Comment[gv]=Stoo Sanpleyr son Ubuntu
Comment[he]=תוכן לדוגמה עבור אובונטו
Comment[hi]=उबुन्टू हेतु उदाहरण सारांश
Comment[hr]=Primjeri sadržaja za Ubuntu
Comment[ht]=Kontni egzanplè pou Ubuntu
Comment[hu]=Mintatartalom Ubuntuhoz
Comment[hy]=Բովանդակության օրինակները Ubuntu֊ի համար
Comment[id]=Contoh isi bagi Ubuntu
Comment[is]=Sýnishorn fyrir Ubuntu
Comment[it]=Contenuti di esempio per Ubuntu
Comment[ja]=Ubuntuのサンプルコンテンツ
Comment[ka]=უბუნტუს სანიმუშო შიგთავსი
Comment[kk]=Ubuntu құжаттар мысалдары
Comment[kl]=Ubuntu-mut imarisaanut assersuut
Comment[km]=ឧទាហរណ៍សម្រាប់អាប់ប៊ុនធូ
Comment[kn]=ಉಬುಂಟುಗೆ ಉದಾಹರಣೆಗಳು
Comment[ko]=우분투 컨텐츠 예시
Comment[ku]=Ji bo Ubuntu mînaka naverokê
Comment[ky]=Ubuntu-нун мисал документтери
Comment[lb]=Beispillinhalt fir Ubuntu
Comment[lt]=Įvairių dokumentų, paveikslėlių, garsų bei vaizdų pavyzdžiai
Comment[lv]=Parauga saturs Ubuntu videi
Comment[mg]=Ohatra ho an'i Ubuntu
Comment[mhr]=Ubuntu-лан документ-влакын пример-влак
Comment[mi]=Mata tauira o Ubuntu
Comment[mk]=Пример содржина за Убунту
Comment[ml]=ഉബുണ്ടുവിനു വേണ്ടിയുള്ള ഉദാഹരണങ്ങള്‍
Comment[mr]=उबंटूसाठी घटकांची उदाहरणे
Comment[ms]=Kandungan contoh untuk Ubuntu
Comment[my]=Ubuntu အတွက် နမူနာ မာတိကာ
Comment[nb]=Eksempelinnhold for Ubuntu
Comment[ne]=उबन्टुका लागि उदाहरण सामग्री
Comment[nl]=Voorbeeldinhoud voor Ubuntu
Comment[nn]=Eksempelinnhald for Ubuntu
Comment[nso]=Mohlala wa dikagare tša Ubuntu
Comment[oc]=Exemples de contengut per Ubuntu
Comment[pa]=ਉਬਤੂੰ ਲਈ ਨਮੂਨਾ ਸਮੱਗਰੀ
Comment[pl]=Przykładowa zawartość dla Ubuntu
Comment[pt]=Conteúdo de exemplo para o Ubuntu
Comment[pt_BR]=Exemplo de conteúdo para Ubuntu
Comment[ro]=Conținut exemplu pentru Ubuntu
Comment[ru]=Примеры документов для Ubuntu
Comment[sc]=Esempiu de cabidu pro Ubuntu
Comment[sco]=Example content fur Ubuntu
Comment[sd]=اوبنٽو لاءِ مثال طور ڏنل مواد
Comment[shn]=တူဝ်ႇယၢင်ႇလမ်းၼႂ်း တႃႇ Ubuntu
Comment[si]=උබුන්ටු සඳහා උදාහරණ අන්තර්ගතයන්
Comment[sk]=Ukážkový obsah pre Ubuntu
Comment[sl]=Ponazoritvena vsebina za Ubuntu
Comment[sml]=Saupama Isina Ubuntu
Comment[sn]=Muyenzaniso wehuiswa kuitira Ubuntu
Comment[sq]=Shembull i përmbajtjes për Ubuntu
Comment[sr]=Садржај примера за Убунту
Comment[sv]=Exempelinnehåll för Ubuntu
Comment[sw]=Bidhaa mfano ya Ubuntu
Comment[szl]=Bajszpilnŏ treść dlŏ Ubuntu
Comment[ta]=உபுண்டுவிற்கான எடுத்துகாட்டு உள்ளடக்கங்கள்
Comment[ta_LK]=உபுண்டுவிற்கான எடுத்துகாட்டு உள்ளடக்கங்கள்
Comment[te]=Ubuntu వాడుక విధాన నమూనాలు
Comment[tg]=Мӯҳтавои намунавӣ барои Ubuntu
Comment[th]=ตัวอย่างข้อมูลสำหรับ Ubuntu
Comment[tr]=Ubuntu için örnek içerik
Comment[tt]=Ubuntu өчен документ мисаллары
Comment[ug]=ئۇبۇنتۇنىڭ مىساللىرى
Comment[uk]=Приклади контенту для Ubuntu
Comment[ur]=یوبنٹو کیلئے مثالی مواد
Comment[uz]=Ubuntu учун намуна таркиби
Comment[vec]=Contenuti de esempio de Ubuntu
Comment[vi]=Mẫu ví dụ cho Ubuntu
Comment[wae]=D'Ubuntu bischbildatijä
Comment[zh_CN]=Ubuntu 示例内容
Comment[zh_HK]=Ubuntu 的範例內容
Comment[zh_TW]=Ubuntu 的範例內容
URL=file:///usr/share/example-content/
Icon=folder
X-Ubuntu-Gettext-Domain=example-content
```
