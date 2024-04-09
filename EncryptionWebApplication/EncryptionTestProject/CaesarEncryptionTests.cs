using EncryptionWebApplication.Services;

namespace EncryptionTestProject
{
    public class CaesarEncryptionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        string sourceTextENG = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.";

        string sourceTextUKR = "Вочевидь, зараз не всі пригадають цю серпневу дату – вісімнадцяте святкування Дня Незалежності України. Відлік десятилітньої історії Вишиванкового фестивалю розпочався саме тоді, коли сімдесят дев’ять людей, убраних у виши́ванки, утворили вздовж Потьомкінських сходів так званий «живий ланцюг». Амбітні плани організаторів повністю виправдалися: він сягнув-таки берега моря. Простягаючись білою ниткою від п’єдесталу пам’ятника Рішельє, ланцюг із року в рік ставав усе довшим, а разом із цим зростало й усвідомлення Одеси як українського міста.";


        [Test]
        public void TestEngLangStep0_Encrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = sourceTextENG;


            var a = caesarEncryptionService.Encrypt(sourceTextENG, 0);
            Assert.AreEqual(encryptedText, a);
        }

        [Test]
        public void TestEngLangStep1_Encrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Mpsfn Jqtvn jt tjnqmz evnnz ufyu pg uif qsjoujoh boe uzqftfuujoh joevtusz. Mpsfn Jqtvn ibt cffo uif joevtusz't tuboebse evnnz ufyu fwfs tjodf uif 1500t, xifo bo volopxo qsjoufs uppl b hbmmfz pg uzqf boe tdsbncmfe ju up nblf b uzqf tqfdjnfo cppl.";

            var a = caesarEncryptionService.Encrypt(sourceTextENG, 1);
            Assert.AreEqual(encryptedText, a);
        }

        [Test]
        public void TestEngLangStep2_Encrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Nqtgo Kruwo ku ukorna fwooa vgzv qh vjg rtkpvkpi cpf vargugvvkpi kpfwuvta. Nqtgo Kruwo jcu dggp vjg kpfwuvta'u uvcpfctf fwooa vgzv gxgt ukpeg vjg 1500u, yjgp cp wpmpqyp rtkpvgt vqqm c icnnga qh varg cpf uetcodngf kv vq ocmg c varg urgekogp dqqm.";
            var a = caesarEncryptionService.Encrypt(sourceTextENG, 2);
            Assert.AreEqual(encryptedText, a);
        }

        [Test]
        public void TestEngLangStep6_Encrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Ruxks Ovyas oy yosvre jasse zkdz ul znk vxotzotm gtj zevkykzzotm otjayzxe. Ruxks Ovyas ngy hkkt znk otjayzxe'y yzgtjgxj jasse zkdz kbkx yotik znk 1500y, cnkt gt atqtuct vxotzkx zuuq g mgrrke ul zevk gtj yixgshrkj oz zu sgqk g zevk yvkioskt huuq.";
            var a = caesarEncryptionService.Encrypt(sourceTextENG, 6);
            Assert.AreEqual(encryptedText, a);
        }

        [Test]
        public void TestEngLangStep25_Encrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Knqdl Hortl hr rhlokx ctllx sdws ne sgd oqhmshmf zmc sxodrdsshmf hmctrsqx. Knqdl Hortl gzr addm sgd hmctrsqx'r rszmczqc ctllx sdws dudq rhmbd sgd 1500r, vgdm zm tmjmnvm oqhmsdq snnj z fzkkdx ne sxod zmc rbqzlakdc hs sn lzjd z sxod rodbhldm annj.";
            var a = caesarEncryptionService.Encrypt(sourceTextENG, 25);
            Assert.AreEqual(encryptedText, a);
        }




        [Test]
        public void TestEngLangStep0_Decrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = sourceTextENG;



            var a = caesarEncryptionService.Encrypt(encryptedText, 0);
            Assert.AreEqual(encryptedText, a);
        }

        [Test]
        public void TestEngLangStep1_Decrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Mpsfn Jqtvn jt tjnqmz evnnz ufyu pg uif qsjoujoh boe uzqftfuujoh joevtusz. Mpsfn Jqtvn ibt cffo uif joevtusz't tuboebse evnnz ufyu fwfs tjodf uif 1500t, xifo bo volopxo qsjoufs uppl b hbmmfz pg uzqf boe tdsbncmfe ju up nblf b uzqf tqfdjnfo cppl.";

            var a = caesarEncryptionService.Decrypt(encryptedText, 1);
            Assert.AreEqual(sourceTextENG, a);
        }

        [Test]
        public void TestEngLangStep2_Decrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Nqtgo Kruwo ku ukorna fwooa vgzv qh vjg rtkpvkpi cpf vargugvvkpi kpfwuvta. Nqtgo Kruwo jcu dggp vjg kpfwuvta'u uvcpfctf fwooa vgzv gxgt ukpeg vjg 1500u, yjgp cp wpmpqyp rtkpvgt vqqm c icnnga qh varg cpf uetcodngf kv vq ocmg c varg urgekogp dqqm.";
            var a = caesarEncryptionService.Decrypt(encryptedText, 2);
            Assert.AreEqual(sourceTextENG, a);
        }

        [Test]
        public void TestEngLangStep6_Decrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Ruxks Ovyas oy yosvre jasse zkdz ul znk vxotzotm gtj zevkykzzotm otjayzxe. Ruxks Ovyas ngy hkkt znk otjayzxe'y yzgtjgxj jasse zkdz kbkx yotik znk 1500y, cnkt gt atqtuct vxotzkx zuuq g mgrrke ul zevk gtj yixgshrkj oz zu sgqk g zevk yvkioskt huuq.";
            var a = caesarEncryptionService.Decrypt(encryptedText, 6);
            Assert.AreEqual(sourceTextENG, a);
        }

        [Test]
        public void TestEngLangStep25_Decrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Knqdl Hortl hr rhlokx ctllx sdws ne sgd oqhmshmf zmc sxodrdsshmf hmctrsqx. Knqdl Hortl gzr addm sgd hmctrsqx'r rszmczqc ctllx sdws dudq rhmbd sgd 1500r, vgdm zm tmjmnvm oqhmsdq snnj z fzkkdx ne sxod zmc rbqzlakdc hs sn lzjd z sxod rodbhldm annj.";
            var a = caesarEncryptionService.Decrypt(encryptedText, 25);
            Assert.AreEqual(sourceTextENG, a);
        }



        [Test]
        public void TestUkrLangStep0_Encrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = sourceTextUKR;
            var a = caesarEncryptionService.Encrypt(sourceTextUKR, 0);
            Assert.AreEqual(encryptedText, a);
        }

        [Test]
        public void TestUkrLangStep1_Encrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Гпшєгіею, ибсби оє гтї рсіґбебяую чя тєсроєгф ебуф – гїтїнобечаує тгаулфгбооа Еоа Оєибмєзоптуї Флсбйоі. Гїемїл еєтауімїуоюпй їтупсїй Гіщігболпгпґп хєтуігбмя спирпшбгта тбнє упеї, лпмі тїнеєтау еєг’аую мяеєк, фвсбоіц ф гіщі́гболі, фугпсімі гиепгз Рпуюпнлїотюліц тцпеїг убл игбоік «зігік мбочяґ». Бнвїуої рмбоі псґбоїибупсїг рпгоїтуя гірсбгебміта: гїо таґофг-ублі вєсєґб нпса. Рсптуаґбяшітю вїмпя оіулпя гїе р’жеєтубмф рбн’ауоілб Сїщємюж, мбочяґ їи сплф г сїл тубгбг фтє епгщін, б сбипн їи чін исптубмп к фтгїепнмєооа Пеєті ал флсбйотюлпґп нїтуб.";

            var a = caesarEncryptionService.Encrypt(sourceTextUKR, 1);
            Assert.AreEqual(encryptedText, a);
        }

        [Test]
        public void TestUkrLangStep2_Encrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Ґрщжґїєя, івтві пж ґуй стїдвєвафя ша ужтспжґх євфх – ґйуйопвєшбфж уґбфмхґвппб Єпб Пжівнжипруфй Хмтвкпї. Ґйєнйм єжубфїнйфпярк йуфртйк Ґїьїґвпмрґрдр цжуфїґвна трісрщвґуб увож фрєй, мрнї уйоєжубф єжґ’бфя наєжл, хгтвпїч х ґїьї́ґвпмї, хфґртїнї ґієрґи Срфяромйпуямїч учрєйґ фвм іґвпїл «иїґїл нвпшад». Вогйфпй снвпї ртдвпйівфртйґ срґпйуфа ґїствґєвнїуб: ґйп убдпхґ-фвмї гжтждв ортб. Струфбдващїуя гйнра пїфмра ґйє с’зєжуфвнх сво’бфпїмв Тйьжняз, нвпшад йі трмх ґ тйм уфвґвґ хуж єрґьїо, в твіро йі шїо ітруфвнр л хуґйєронжппб Рєжуї бм хмтвкпуямрдр ойуфв.";
            var a = caesarEncryptionService.Encrypt(sourceTextUKR, 2);
            Assert.AreEqual(encryptedText, a);
        }

        [Test]
        public void TestUkrLangStep6_Encrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Жфаїжміг, лецел уї жчн хцмзеіеґшг яґ чїцхуїжщ іешщ – жнчнтуеіядшї чждшрщжеууд Іуд Уїлесїкуфчшн Щрцеоум. Жніснр іїчдшмсншугфо нчшфцно Жмбмжеурфжфзф ьїчшмжесґ цфлхфаежчд четї шфін, рфсм чнтіїчдш іїж’дшг сґіїп, щєцеумю щ жмбм́жеурм, щшжфцмсм жліфжк Хфшгфтрнучгрмю чюфінж шер лжеумп «кмжмп сеуяґз». Етєншун хсеум фцзеунлешфцнж хфжунчшґ жмхцежіесмчд: жну чдзущж-шерм єїцїзе тфцд. Хцфчшдзеґамчг єнсфґ умшрфґ жні х’йіїчшесщ хет’дшумре Цнбїсгй, сеуяґз нл цфрщ ж цнр чшежеж щчї іфжбмт, е целфт нл ямт лцфчшесф п щчжніфтсїууд Фіїчм др щрцеоучгрфзф тнчше.";
            var a = caesarEncryptionService.Encrypt(sourceTextUKR, 6);
            Assert.AreEqual(encryptedText, a);
        }

        [Test]
        public void TestUkrLangStep32_Encrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Бнцдбзґщ, жяпяж мд бри опзвяґяьсщ хь рдпомдбт ґяст – бирилмяґхюсд рбюсйтбяммю Ґмю Мджякдємнрси Тйпяімз. Биґкий ґдрюсзкисмщні ирснпиі Бзчзбямйнбнвн удрсзбякь пнжонцябрю рялд снґи, йнкз рилґдрюс ґдб’юсщ кьґдї, тапямзф т бзчз́бямйз, тсбнпзкз бжґнбє Онсщнлйимрщйзф рфнґиб сяй жбямзї «єзбзї кямхьв». Ялаисми окямз нпвямижяснпиб онбмирсь бзопябґякзрю: бим рювмтб-сяйз адпдвя лнпю. Опнрсювяьцзрщ аикнь мзсйнь биґ о’еґдрсякт оял’юсмзйя Пичдкще, кямхьв иж пнйт б пий рсябяб трд ґнбчзл, я пяжнл иж хзл жпнрсякн ї трбиґнлкдммю Нґдрз юй тйпяімрщйнвн лирся.";
            var a = caesarEncryptionService.Encrypt(sourceTextUKR, 32);
            Assert.AreEqual(encryptedText, a);
        }





        [Test]
        public void TestUkrLangStep0_Decrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = sourceTextUKR;
            var a = caesarEncryptionService.Encrypt(encryptedText, 0);
            Assert.AreEqual(sourceTextUKR, a);
        }

        [Test]
        public void TestUkrLangStep1_Decrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Гпшєгіею, ибсби оє гтї рсіґбебяую чя тєсроєгф ебуф – гїтїнобечаує тгаулфгбооа Еоа Оєибмєзоптуї Флсбйоі. Гїемїл еєтауімїуоюпй їтупсїй Гіщігболпгпґп хєтуігбмя спирпшбгта тбнє упеї, лпмі тїнеєтау еєг’аую мяеєк, фвсбоіц ф гіщі́гболі, фугпсімі гиепгз Рпуюпнлїотюліц тцпеїг убл игбоік «зігік мбочяґ». Бнвїуої рмбоі псґбоїибупсїг рпгоїтуя гірсбгебміта: гїо таґофг-ублі вєсєґб нпса. Рсптуаґбяшітю вїмпя оіулпя гїе р’жеєтубмф рбн’ауоілб Сїщємюж, мбочяґ їи сплф г сїл тубгбг фтє епгщін, б сбипн їи чін исптубмп к фтгїепнмєооа Пеєті ал флсбйотюлпґп нїтуб.";

            var a = caesarEncryptionService.Decrypt(encryptedText, 1);
            Assert.AreEqual(sourceTextUKR, a);
        }

        [Test]
        public void TestUkrLangStep2_Decrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Ґрщжґїєя, івтві пж ґуй стїдвєвафя ша ужтспжґх євфх – ґйуйопвєшбфж уґбфмхґвппб Єпб Пжівнжипруфй Хмтвкпї. Ґйєнйм єжубфїнйфпярк йуфртйк Ґїьїґвпмрґрдр цжуфїґвна трісрщвґуб увож фрєй, мрнї уйоєжубф єжґ’бфя наєжл, хгтвпїч х ґїьї́ґвпмї, хфґртїнї ґієрґи Срфяромйпуямїч учрєйґ фвм іґвпїл «иїґїл нвпшад». Вогйфпй снвпї ртдвпйівфртйґ срґпйуфа ґїствґєвнїуб: ґйп убдпхґ-фвмї гжтждв ортб. Струфбдващїуя гйнра пїфмра ґйє с’зєжуфвнх сво’бфпїмв Тйьжняз, нвпшад йі трмх ґ тйм уфвґвґ хуж єрґьїо, в твіро йі шїо ітруфвнр л хуґйєронжппб Рєжуї бм хмтвкпуямрдр ойуфв.";
            var a = caesarEncryptionService.Decrypt(encryptedText, 2);
            Assert.AreEqual(sourceTextUKR, a);
        }

        [Test]
        public void TestUkrLangStep6_Decrypt()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Жфаїжміг, лецел уї жчн хцмзеіеґшг яґ чїцхуїжщ іешщ – жнчнтуеіядшї чждшрщжеууд Іуд Уїлесїкуфчшн Щрцеоум. Жніснр іїчдшмсншугфо нчшфцно Жмбмжеурфжфзф ьїчшмжесґ цфлхфаежчд четї шфін, рфсм чнтіїчдш іїж’дшг сґіїп, щєцеумю щ жмбм́жеурм, щшжфцмсм жліфжк Хфшгфтрнучгрмю чюфінж шер лжеумп «кмжмп сеуяґз». Етєншун хсеум фцзеунлешфцнж хфжунчшґ жмхцежіесмчд: жну чдзущж-шерм єїцїзе тфцд. Хцфчшдзеґамчг єнсфґ умшрфґ жні х’йіїчшесщ хет’дшумре Цнбїсгй, сеуяґз нл цфрщ ж цнр чшежеж щчї іфжбмт, е целфт нл ямт лцфчшесф п щчжніфтсїууд Фіїчм др щрцеоучгрфзф тнчше.";
            var a = caesarEncryptionService.Decrypt(encryptedText, 6);
            Assert.AreEqual(sourceTextUKR, a);
        }

        [Test]
        public void TestUkrLangStep32_Decrypt()
        {

            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Бнцдбзґщ, жяпяж мд бри опзвяґяьсщ хь рдпомдбт ґяст – бирилмяґхюсд рбюсйтбяммю Ґмю Мджякдємнрси Тйпяімз. Биґкий ґдрюсзкисмщні ирснпиі Бзчзбямйнбнвн удрсзбякь пнжонцябрю рялд снґи, йнкз рилґдрюс ґдб’юсщ кьґдї, тапямзф т бзчз́бямйз, тсбнпзкз бжґнбє Онсщнлйимрщйзф рфнґиб сяй жбямзї «єзбзї кямхьв». Ялаисми окямз нпвямижяснпиб онбмирсь бзопябґякзрю: бим рювмтб-сяйз адпдвя лнпю. Опнрсювяьцзрщ аикнь мзсйнь биґ о’еґдрсякт оял’юсмзйя Пичдкще, кямхьв иж пнйт б пий рсябяб трд ґнбчзл, я пяжнл иж хзл жпнрсякн ї трбиґнлкдммю Нґдрз юй тйпяімрщйнвн лирся.";
            var a = caesarEncryptionService.Decrypt(encryptedText, 32);
            Assert.AreEqual(sourceTextUKR, a);
        }


       /* [Test]
        public void TestEngLangStep25_Atack()
        {
            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Knqdl Hortl hr rhlokx ctllx sdws ne sgd oqhmshmf zmc sxodrdsshmf hmctrsqx. Knqdl Hortl gzr addm sgd hmctrsqx'r rszmczqc ctllx sdws dudq rhmbd sgd 1500r, vgdm zm tmjmnvm oqhmsdq snnj z fzkkdx ne sxod zmc rbqzlakdc hs sn lzjd z sxod rodbhldm annj.";
            var a = caesarEncryptionService.Attack(sourceTextENG, encryptedText);

            Assert.AreEqual("25", a);
        }*/



       /* [Test]
        public void TestUkrLangStep32_Atack()
        {

            CaesarEncryptionService caesarEncryptionService = new CaesarEncryptionService();

            var encryptedText = "Бнцдбзґщ, жяпяж мд бри опзвяґяьсщ хь рдпомдбт ґяст – бирилмяґхюсд рбюсйтбяммю Ґмю Мджякдємнрси Тйпяімз. Биґкий ґдрюсзкисмщні ирснпиі Бзчзбямйнбнвн удрсзбякь пнжонцябрю рялд снґи, йнкз рилґдрюс ґдб’юсщ кьґдї, тапямзф т бзчз́бямйз, тсбнпзкз бжґнбє Онсщнлйимрщйзф рфнґиб сяй жбямзї «єзбзї кямхьв». Ялаисми окямз нпвямижяснпиб онбмирсь бзопябґякзрю: бим рювмтб-сяйз адпдвя лнпю. Опнрсювяьцзрщ аикнь мзсйнь биґ о’еґдрсякт оял’юсмзйя Пичдкще, кямхьв иж пнйт б пий рсябяб трд ґнбчзл, я пяжнл иж хзл жпнрсякн ї трбиґнлкдммю Нґдрз юй тйпяімрщйнвн лирся.";
            var a = caesarEncryptionService.Attack(sourceTextUKR, encryptedText);

            Assert.AreEqual("32", a);

        }*/
    }
}