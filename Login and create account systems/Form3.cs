using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.IO;





namespace Login_and_create_account_systems
{
    public partial class Form3 : Form
    {
        private string connectionString = "Data Source=styleforge-ms-sql-server.ch0q4qge64ch.eu-north-1.rds.amazonaws.com;Initial Catalog=StyleForgeDB;Persist Security Info=True;User ID=admin;Password=StyleForge#123;Trust Server Certificate=True";
        public string destinationPath = GlobalSettings.DestinationPath;
        public string imageUrl;
        


        public string jsonRes = "{\r\n    \"top_wear_search_engine_query_result1_title\": \"Locomotive Men Checkered Casual Black, Grey Shirt\",\r\n    \"top_wear_search_engine_query_result1_price\": \"₹499.00\",\r\n    \"top_wear_search_engine_query_result1_url\": \"https://www.google.com/shopping/product/10777551841674272842?hl=en&q=normal+fitting+shirts+for+men&prds=eto:14370226796022785315_0,pid:15908996925132344090,rsk:PC_16794004679943600786&sa=X&ved=0ahUKEwjBpZKQy8KKAxWLslYBHVruOgEQ8gIIjA8oAA\",\r\n    \"top_wear_search_engine_query_result1_image_url\": \"https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcTZl5EkCiaYt19Kn5VD6yr9-EygAme2cw4hB6XYH2ao6HnHS9Gq2vyGvJDJIWoT8slk2YUz1MziINgmRuth25vuKN1bGA3BRA&usqp=CAY\",\r\n    \"top_wear_search_engine_query_result1_buy_now_url\": \"https://www.google.com/url?q=http://www.myntra.com/Shirts/LOCOMOTIVE/LOCOMOTIVE-Men-Black--Grey-Slim-Fit-Checked-Casual-Shirt/10341699/buy&opi=95576897&sa=U&ved=0ahUKEwjj-rWRy8KKAxXsT2wGHQNQOaUQ1ykIFQ&usg=AOvVaw2hr8pK57CuiCVEJ8Pqi8G3\",\r\n    \"top_wear_search_engine_query_result2_title\": \"Men Solid Formal Black Shirt\",\r\n    \"top_wear_search_engine_query_result2_price\": \"₹313.00\",\r\n    \"top_wear_search_engine_query_result2_url\": \"https://www.google.com/shopping/product/8315703008094576011?hl=en&q=normal+fitting+shirts+for+men&prds=eto:10990651489261804095_0,pid:120543845696355704&sa=X&ved=0ahUKEwjBpZKQy8KKAxWLslYBHVruOgEQ8gIImQ8oAA\",\r\n    \"top_wear_search_engine_query_result2_image_url\": \"https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcRatFPXwe-0A1tZAATj-K3yri-HbJKX2dGW6XJzOYLef9q06za1KOIy7IToF3x_QL0FFWhR7UTr5pPQWqMgiZ6sxCNpm5RTr36-zYvotlrs&usqp=CAY\",\r\n    \"top_wear_search_engine_query_result2_buy_now_url\": \"https://www.google.com/url?q=https://www.shopsy.in/men-solid-formal-black-shirt/p/itmd08a7500a3d46%3Fpid%3DXSRGGP5QVMKGE425%26lid%3DLSTXSRGGP5QVMKGE425VDLMKW%26marketplace%3DFLIPKART&opi=95576897&sa=U&ved=0ahUKEwitn_-Ry8KKAxVaS2wGHX_aPC4Q1ykIFQ&usg=AOvVaw18OHVyey0YMexAU9-NuHXJ\",\r\n    \"top_wear_search_engine_query_result3_title\": \"Roadster Men Grey Solid Regular Fit Pure Cotton Casual Shirt (38) by Myntra\",\r\n    \"top_wear_search_engine_query_result3_price\": \"₹665.00\",\r\n    \"top_wear_search_engine_query_result3_url\": \"https://www.google.com/shopping/product/7790028291484788041?hl=en&q=normal+fitting+shirts+for+men&prds=eto:2523908464313114090_0,pid:15743598485591213493&sa=X&ved=0ahUKEwjBpZKQy8KKAxWLslYBHVruOgEQ8gIIpA8oAA\",\r\n    \"top_wear_search_engine_query_result3_image_url\": \"https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcQuGV6tnt1wxfIqqFQ4R94lKM2PuBji5Dq20I_rACIPzfZj2dw2t1rbP1lO0f1rpFOCcRLHuU57rqdIUyL_IouJ3sgjzmIRlg&usqp=CAY\",\r\n    \"top_wear_search_engine_query_result3_buy_now_url\": \"https://www.google.com/url?q=http://www.myntra.com/Shirts/Roadster/Roadster-Men-Grey-Solid-Regular-Fit-Pure-Cotton-Casual-Shirt/15557630/buy&opi=95576897&sa=U&ved=0ahUKEwjQ3LaSy8KKAxV9SWwGHSanGGsQ1ykIFQ&usg=AOvVaw1cG_xwMTIsS_ahK-enWfuE\",\r\n    \"top_wear_search_engine_query_result4_title\": \"Blive Solid Men High Neck White T-shirt\",\r\n    \"top_wear_search_engine_query_result4_price\": \"₹359.00\",\r\n    \"top_wear_search_engine_query_result4_url\": \"https://www.google.com/shopping/product/18294909045527790049?hl=en&q=normal+fitting+shirts+for+men&prds=eto:5589490374459279150_0,pid:45751453728941854&sa=X&ved=0ahUKEwjBpZKQy8KKAxWLslYBHVruOgEQ8gIIrw8oAA\",\r\n    \"top_wear_search_engine_query_result4_image_url\": \"https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcSye-dtyIPercAhsfX4itb1apSNkFeIDf7raZNGNKnzyVjQJXGInyW88fZyLjacY2UejuQhuX54150_qpNRSManZPGi0Fuq&usqp=CAY\",\r\n    \"top_wear_search_engine_query_result4_buy_now_url\": \"https://www.google.com/url?q=http://www.flipkart.com/blive-solid-men-high-neck-white-t-shirt/p/itmdb762ca4ec2e8%3Fpid%3DTSHH6YKHFTU3NFVU%26lid%3DLSTTSHH6YKHFTU3NFVUTCAU5J%26marketplace%3DFLIPKART%26cmpid%3Dcontent_t-shirt_8965229628_gmc&opi=95576897&sa=U&ved=0ahUKEwiXivGSy8KKAxXLS2wGHc6cKtgQ1ykIFQ&usg=AOvVaw3XRdG5PjVB34FVgxN2zUJe\",\r\n    \"top_wear_search_engine_query_result5_title\": \"The Indian Garage Co. Men Striped Casual White Shirt\",\r\n    \"top_wear_search_engine_query_result5_price\": \"₹585.00\",\r\n    \"top_wear_search_engine_query_result5_url\": \"https://www.google.com/shopping/product/3224250771286959012?hl=en&q=normal+fitting+shirts+for+men&prds=eto:9405661387200549374_0,pid:14015701653161757098,rsk:PC_1837918737675362908&sa=X&ved=0ahUKEwjBpZKQy8KKAxWLslYBHVruOgEQ8gIIug8oAA\",\r\n    \"top_wear_search_engine_query_result5_image_url\": \"https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcTc-f_YSHoMuxpKVjisH8TNEWXk0LqRHOGii22aSFHGYgo7YKdR4zyDDv_sJRCJzwbOvRgVNGYLhGdhpNmVo_fCm81lUmPcng&usqp=CAY\",\r\n    \"top_wear_search_engine_query_result5_buy_now_url\": \"https://www.google.com/url?q=https://tigc.in/products/0619-sh04-white%3Fvariant%3D44236899516632%26country%3DIN%26currency%3DINR%26utm_medium%3Dproduct_sync%26utm_source%3Dgoogle%26utm_content%3Dsag_organic%26utm_campaign%3Dsag_organic%26srsltid%3DAfmBOoocN0fZDLLnp42ppRStQ1TiZkMPiHE0ztitCVEzeiKlzEcy_C1dgfQ&opi=95576897&sa=U&ved=0ahUKEwj1gLOTy8KKAxXUUGwGHRSoE6gQ1ykIFg&usg=AOvVaw2T908Es_SoOxN0i9wi0vcz\",\r\n    \"bottom_wear_search_engine_query_result1_title\": \"EYEBOGLER Men Relaxed Fit Flat-Front Chinos For Men (Silver, 34)\",\r\n    \"bottom_wear_search_engine_query_result1_price\": \"₹575.00\",\r\n    \"bottom_wear_search_engine_query_result1_url\": \"https://www.google.com/shopping/product/16694457012752166822?hl=en&q=pants+for+men&prds=eto:15327069267947319461_0,pid:176693775552132348&sa=X&ved=0ahUKEwi11aOUy8KKAxVNdPUHHZoDMhcQ8gIIig0oAA\",\r\n    \"bottom_wear_search_engine_query_result1_image_url\": \"https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSa0YAwS8lhN7xPI3AwwtyfXWNKCh2E9INkwPvntbsw2KmwugQBSRtqKx116eMUyWl4T3DXRU_eJVAOhG-NezAHzu9UfTOV&usqp=CAY\",\r\n    \"bottom_wear_search_engine_query_result1_buy_now_url\": \"https://www.google.com/url?q=https://www.ajio.com/eyebogler-men-relaxed-fit-flat-front-chinos/p/700212383_silver%3Fsrsltid%3DAfmBOoo_bsyTCKZc5vqSEad1tOOY1b_q0xRU4wiab8zTm7GYgIni9ez0LKY%23gmf&opi=95576897&sa=U&ved=0ahUKEwj9n6eVy8KKAxVATWwGHfo1MmoQ1ykIGQ&usg=AOvVaw2Hr5XsDdxZDBT5ysnnz6C3\",\r\n    \"bottom_wear_search_engine_query_result2_title\": \"Highlander Solid Men Green Track Pants\",\r\n    \"bottom_wear_search_engine_query_result2_price\": \"₹399.00\",\r\n    \"bottom_wear_search_engine_query_result2_url\": \"https://www.google.com/shopping/product/13591501492427942536?hl=en&q=pants+for+men&prds=eto:7224938771446065498_0,pid:6568404961897200198,rsk:PC_7958150559681245667&sa=X&ved=0ahUKEwi11aOUy8KKAxVNdPUHHZoDMhcQ8gIIlQ0oAA\",\r\n    \"bottom_wear_search_engine_query_result2_image_url\": \"https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSBHC888XQYJCJFxwUm1w9dcQTh5s_8TKpVXHk1ludOXVOW-k_6F8iRGIHuHEPKUz4BmKfUugYFEfDFOmL1DGsSv-vF1WYP1w&usqp=CAY\",\r\n    \"bottom_wear_search_engine_query_result2_buy_now_url\": \"https://www.google.com/url?q=http://www.myntra.com/Track-Pants/HIGHLANDER/HIGHLANDER-Men-Olive-Green-Solid-Slim-Fit-Track-Pants/13861868/buy&opi=95576897&sa=U&ved=0ahUKEwiWg9mVy8KKAxVjU2wGHc2NBSIQ1ykIFQ&usg=AOvVaw3-_m_vVUCo1ENvkkfPOQNf\",\r\n    \"bottom_wear_search_engine_query_result3_title\": \"Off Duty | Men Semi Formal Straight Fit Korean Pants White / 36\",\r\n    \"bottom_wear_search_engine_query_result3_price\": \"₹1,590.00\",\r\n    \"bottom_wear_search_engine_query_result3_url\": \"https://www.google.com/shopping/product/1210304552594535898?hl=en&q=pants+for+men&prds=eto:13228588360269837400_0,pid:12184843570144608028&sa=X&ved=0ahUKEwi11aOUy8KKAxVNdPUHHZoDMhcQ8gIIog0oAA\",\r\n    \"bottom_wear_search_engine_query_result3_image_url\": \"https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcRnLH14p2ue8PuRMNE4bLDPCSr5rTWAsaJmPUwGwHYuQp4zWFApwEfKcVy7IkY1tM1iHYHiZ6H9jci632whiu9rKYKd4uc0&usqp=CAY\",\r\n    \"bottom_wear_search_engine_query_result3_buy_now_url\": \"https://www.google.com/url?q=https://offduty.in/products/men-semi-formal-straight-fit-korean-pants%3Fvariant%3D41734628081761%26country%3DIN%26currency%3DINR%26utm_medium%3Dproduct_sync%26utm_source%3Dgoogle%26utm_content%3Dsag_organic%26utm_campaign%3Dsag_organic%26srsltid%3DAfmBOooBlGKsiYCPSTaRraOvUrTU0EstgcmnPSGtaCJm19ybiFuc5ge3X8w&opi=95576897&sa=U&ved=0ahUKEwit96CWy8KKAxXvW2wGHW2wJfcQ1ykIFQ&usg=AOvVaw18f1GVHqZHR1jJlYKZjWHL\",\r\n    \"bottom_wear_search_engine_query_result4_title\": \"The Indian Garage Co. Slim Fit Men Green Trousers\",\r\n    \"bottom_wear_search_engine_query_result4_price\": \"₹570.00\",\r\n    \"bottom_wear_search_engine_query_result4_url\": \"https://www.google.com/shopping/product/2196226989469843557?hl=en&q=pants+for+men&prds=eto:12181097665313578668_0,pid:5189271456820232812,rsk:PC_6279028525816452618&sa=X&ved=0ahUKEwi11aOUy8KKAxVNdPUHHZoDMhcQ8gIIrQ0oAA\",\r\n    \"bottom_wear_search_engine_query_result4_image_url\": \"https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcQlWUeYJ8xo5UrNDYjxqYiD3HhAb1WVpZ5VtOO3zoP5PkTkGx9Mv7e7v_1Dt2qpiRgWIVN-0fC64xPp4gloGg8ouvYLGcq-&usqp=CAY\",\r\n    \"bottom_wear_search_engine_query_result4_buy_now_url\": \"https://www.google.com/url?q=http://www.flipkart.com/indian-garage-co-slim-fit-men-green-trousers/p/itmc549067c62dbd%3Fpid%3DTROGZCBH43YTAENT%26lid%3DLSTTROGZCBH43YTAENTJZSJHR%26marketplace%3DFLIPKART%26cmpid%3Dcontent_trouser_8965229628_gmc&opi=95576897&sa=U&ved=0ahUKEwj5-dyWy8KKAxWBSmwGHZsENC0Q1ykIFQ&usg=AOvVaw3vrpv1ekf24cCC_74QnBhw\",\r\n    \"bottom_wear_search_engine_query_result5_title\": \"Off Duty | Korean Baggy Loose Fit Pants For Men Cream / S-30\",\r\n    \"bottom_wear_search_engine_query_result5_price\": \"₹1,699.00\",\r\n    \"bottom_wear_search_engine_query_result5_url\": \"https://www.google.com/shopping/product/16038550850118993066?hl=en&q=pants+for+men&prds=eto:6717676809771338980_0,pid:16611582462616122071&sa=X&ved=0ahUKEwi11aOUy8KKAxVNdPUHHZoDMhcQ8gIIug0oAA\",\r\n    \"bottom_wear_search_engine_query_result5_image_url\": \"https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcS-Zasi76Er33eb0ehyml7plHMBuVLBAokYGnlQfUJ-X0hGKrKMzkVAvy6zP89C3AzoMwqSZ3q6gBFM1xAiYywf8_l_TQxf&usqp=CAY\",\r\n    \"bottom_wear_search_engine_query_result5_buy_now_url\": \"https://www.google.com/url?q=https://offduty.in/products/korean-baggy-loose-fit-pants-for-men-new%3Fvariant%3D41897622601825%26country%3DIN%26currency%3DINR%26utm_medium%3Dproduct_sync%26utm_source%3Dgoogle%26utm_content%3Dsag_organic%26utm_campaign%3Dsag_organic%26srsltid%3DAfmBOoq6q2UweGl9EiJ-O5LJufGevQi05nFg_8mpNW9kSAnU125rBCmX3TM&opi=95576897&sa=U&ved=0ahUKEwjRlJyXy8KKAxUcTWwGHUwsLvYQ1ykIFQ&usg=AOvVaw04Gp-yYmnU87THjV5LqzdG\",\r\n    \"shoes_search_engine_query_result1_title\": \"Red Tape ETPU Athleisure Shoes for Men | Cultured Round-Toe Shape, Smart Ventilation & Drift+ Technology\",\r\n    \"shoes_search_engine_query_result1_price\": \"₹1,679.00\",\r\n    \"shoes_search_engine_query_result1_url\": \"https://www.google.com/shopping/product/15474805695300194162?hl=en&q=sports+sneaker+for+men&prds=eto:752719324856367175_0,pid:9637846338715820143,rsk:PC_17273674703928121022&sa=X&ved=0ahUKEwiCrYKYy8KKAxWlnq8BHY9ZPecQ8gIIqg4oAA\",\r\n    \"shoes_search_engine_query_result1_image_url\": \"https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcSLqkNZhP3mnQKpwdd0nOd46pyv3w4K-2vCWvvp7LUWnvmr0dd1b9s5_YaRCHbrXITuFshid6GydBWYSKq5_BfhuQeMOi2-hg&usqp=CAY\",\r\n    \"shoes_search_engine_query_result1_buy_now_url\": \"https://www.google.com/url?q=http://www.myntra.com/Sports-Shoes/Red%2BTape/Red-Tape-Men-Drift-Round-Toe-Mesh-ETPU-Walking-Shoes/29869640/buy&opi=95576897&sa=U&ved=0ahUKEwissoiZy8KKAxXXSWwGHQnnAjgQ1ykIFQ&usg=AOvVaw2beL-RA8DeUTHngWURdAkD\",\r\n    \"shoes_search_engine_query_result2_title\": \"Red Tape Men Colourblocked Round Toe Sneakers (9) by Myntra\",\r\n    \"shoes_search_engine_query_result2_price\": \"₹2,249.00\",\r\n    \"shoes_search_engine_query_result2_url\": \"https://www.google.com/shopping/product/9130439400301336267?hl=en&q=sports+sneaker+for+men&prds=eto:13896746959566833706_0,pid:5699649965905068720,rsk:PC_12839625519146170983&sa=X&ved=0ahUKEwiCrYKYy8KKAxWlnq8BHY9ZPecQ8gIItw4oAA\",\r\n    \"shoes_search_engine_query_result2_image_url\": \"https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcRegWDVJxXLFjEgBkTzkFhXmuuuVFXTL9l1hUafB2H5A727Pbdu1wf1Ztzh8YcDIEBfE9BcAkWcd8OdnP9E-tdTI7IgobZ9vw&usqp=CAY\",\r\n    \"shoes_search_engine_query_result2_buy_now_url\": \"https://www.google.com/url?q=https://www.nykaafashion.com/red-tape-men-lace-up-round-toe-black-sneakers/p/17782922%3Fadsource%3Dshopping_india%26skuId%3D17782796%26srsltid%3DAfmBOopJdRh9I2RCOzmjDHRDChnpaR8cjXCa-Td1weyGqUUZ9z2UNjt1_xQ&opi=95576897&sa=U&ved=0ahUKEwiI_M6Zy8KKAxXETWwGHckpLd8Q1ykIFQ&usg=AOvVaw1IduxQ9nGxWa5j0FnstzkM\",\r\n    \"shoes_search_engine_query_result3_title\": \"Red Tape Athleisure Shoes for Men | Cultured Round-Toe Shape & Cushioning Technology\",\r\n    \"shoes_search_engine_query_result3_price\": \"₹2,699.00\",\r\n    \"shoes_search_engine_query_result3_url\": \"https://www.google.com/shopping/product/5296000703453775381?hl=en&q=sports+sneaker+for+men&prds=eto:6920481533343158668_0,pid:456442412609551545,rsk:PC_7169657223049070978&sa=X&ved=0ahUKEwiCrYKYy8KKAxWlnq8BHY9ZPecQ8gIIxA4oAA\",\r\n    \"shoes_search_engine_query_result3_image_url\": \"https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcQ_-YZGOtJFX2O_7rhiKfVym78-UTgVMts-Bj3kC37FSrxbkEAQwjPz8cf4Adgwq89oHimGWtLDPPXFhU0Rpns5sUptGyXH&usqp=CAY\",\r\n    \"shoes_search_engine_query_result3_buy_now_url\": \"https://www.google.com/url?q=https://www.nykaaman.com/red-tape-men-textured-green-and-grey-athleisure-walking-shoes/p/17430160%3Fptype%3Dproduct%26skuId%3D17430026&opi=95576897&sa=U&ved=0ahUKEwiDqIeay8KKAxWYSWwGHT_7MiAQ1ykIFQ&usg=AOvVaw32qa1UXqrqzntp-mGJ4e6q\",\r\n    \"shoes_search_engine_query_result4_title\": \"Waulkers White Running,Walking,Training,Sports Shoes,Casual Shoe Sneakers For Men\",\r\n    \"shoes_search_engine_query_result4_price\": \"₹339.00\",\r\n    \"shoes_search_engine_query_result4_url\": \"https://www.google.com/shopping/product/8757607502030042315?hl=en&q=sports+sneaker+for+men&prds=eto:5078910375992466868_0,pid:7130239525013771234&sa=X&ved=0ahUKEwiCrYKYy8KKAxWlnq8BHY9ZPecQ8gII0Q4oAA\",\r\n    \"shoes_search_engine_query_result4_image_url\": \"https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcRU875TxwdOxmy_omRh2bMGzz7NT9t7PkSKvdkzjMafP4TTfJ3llrMKR1d4iVmya13skjwi1OGZyIqaCMf30vggiP_-m8v2&usqp=CAY\",\r\n    \"shoes_search_engine_query_result4_buy_now_url\": \"https://www.google.com/url?q=https://www.shopsy.in/waulkers-white-running-walking-training-sports-shoes-casual-shoe-sneakers-men/p/itm655547e86de8d%3Fpid%3DEOEGG5UYUDPGDKBC%26lid%3DLSTEOEGG5UYUDPGDKBC7C7GYC%26marketplace%3DFLIPKART&opi=95576897&sa=U&ved=0ahUKEwj1gb6ay8KKAxX2UWwGHcrvCj4Q1ykIFQ&usg=AOvVaw17nQGO6jOMlT-IVJOJLH5J\",\r\n    \"shoes_search_engine_query_result5_title\": \"Red Tape Men Colourblocked Sneakers (9) by Myntra\",\r\n    \"shoes_search_engine_query_result5_price\": \"₹2,129.00\",\r\n    \"shoes_search_engine_query_result5_url\": \"https://www.google.com/shopping/product/151394819197976888?hl=en&q=sports+sneaker+for+men&prds=eto:6211304766655503222_0,pid:1643692772432929141&sa=X&ved=0ahUKEwiCrYKYy8KKAxWlnq8BHY9ZPecQ8gII3A4oAA\",\r\n    \"shoes_search_engine_query_result5_image_url\": \"https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcRaPvjBtbHQRFQ-sBEMEKOIh0OxHljzQLZ3YiCRRql8szaT3syseeVz-TMWB2Ng3kDimzXhwTG03W2XA7PaFq9tF8bdptc7MA&usqp=CAY\",\r\n    \"shoes_search_engine_query_result5_buy_now_url\": \"https://www.google.com/url?q=http://www.flipkart.com/red-tape-lifestyle-sneaker-shoes-men-elegantly-rounded-front-soothing-insole-sneakers/p/itmab9901447678a%3Fpid%3DSHOH5Y8F3HE63BY8%26lid%3DLSTSHOH5Y8F3HE63BY8FOWKWS%26marketplace%3DFLIPKART%26cmpid%3Dcontent_shoe_8965229628_gmc&opi=95576897&sa=U&ved=0ahUKEwiJ5fGay8KKAxV6SWwGHRp-AwwQ1ykIFQ&usg=AOvVaw1vsOkWy_lCnBW8CsYmqFZ_\",\r\n    \"color_recommendations_search_engine_query_result1_title\": \"Beyoung Light Sky Blue Over Dyed Shirt For Men\",\r\n    \"color_recommendations_search_engine_query_result1_price\": \"₹999.00\",\r\n    \"color_recommendations_search_engine_query_result1_url\": \"https://www.google.com/shopping/product/9677849480642512323?hl=en&q=sky+tone+colors+for+men&prds=eto:17657613699115951879_0,pid:3521462216318961916&sa=X&ved=0ahUKEwjI5LOby8KKAxWxka8BHWZcChcQ8gIIkQkoAA\",\r\n    \"color_recommendations_search_engine_query_result1_image_url\": \"https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcRnfOWR0O2TjrnWcMBQhr6tRrtkNQCgpZM7WA9YGoLHVPJMxPsKgtJbAtae4lgBzAlcsHit-6PlJTrWVl0P8XfYFzg3m83tDA&usqp=CAY\",\r\n    \"color_recommendations_search_engine_query_result1_buy_now_url\": \"https://www.google.com/url?q=https://www.beyoung.in/light-sky-blue-over-dyed-shirt-for-men%3Fsrsltid%3DAfmBOorUvieFjEBgQ-qSmjP68y0w9EszRimL_l_-owR_Vl2EVcRkr5ay3Y0&opi=95576897&sa=U&ved=0ahUKEwj4gL-cy8KKAxVTTmwGHdliKHQQ1ykIFQ&usg=AOvVaw279tsCqKjC8sZrWiv6zppE\",\r\n    \"color_recommendations_search_engine_query_result2_title\": \"Shop Men's Cotton Regular Fit Sky Blue Color Shirts Online 46 / H/S / Sky Blue\",\r\n    \"color_recommendations_search_engine_query_result2_price\": \"₹825.00\",\r\n    \"color_recommendations_search_engine_query_result2_url\": \"https://www.google.com/shopping/product/8830468920703269734?hl=en&q=sky+tone+colors+for+men&prds=eto:9470384912585313472_0,pid:5487123253978358399&sa=X&ved=0ahUKEwjI5LOby8KKAxWxka8BHWZcChcQ8gIInAkoAA\",\r\n    \"color_recommendations_search_engine_query_result2_image_url\": \"https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcS0L4IvQW9yUvRzfBmnZjYcRgrzQ8I_ZbPoEasiASnx_1V-n0Vrb54UmguLtcDkyRxu1O9F_bx4rnI12c8Lg8Oyh-SMOWw7dthp7lpLQlezklgl-iSFcGyq&usqp=CAY\",\r\n    \"color_recommendations_search_engine_query_result2_buy_now_url\": \"https://www.google.com/url?q=https://www.ministerwhite.com/products/mens-cotton-sky-blue-colour-regular-fit-shirt-oura%3Fvariant%3D48839989526809%26country%3DIN%26currency%3DINR%26utm_medium%3Dproduct_sync%26utm_source%3Dgoogle%26utm_content%3Dsag_organic%26utm_campaign%3Dsag_organic%26srsltid%3DAfmBOop6vWiFUlVwfBc9T8by4FNBq4ffZLeSq0Ypqzng5FOCmJeHBzV-eDw&opi=95576897&sa=U&ved=0ahUKEwjxtfOcy8KKAxUCT2wGHf6LAaIQ1ykIFQ&usg=AOvVaw0rWcVuYW49l1Dn8y_Lfbx-\",\r\n    \"color_recommendations_search_engine_query_result3_title\": \"Lovingvibe Creation Men Solid Formal Light Blue Shirt\",\r\n    \"color_recommendations_search_engine_query_result3_price\": \"₹499.00\",\r\n    \"color_recommendations_search_engine_query_result3_url\": \"https://www.google.com/shopping/product/18282827540542071700?hl=en&q=sky+tone+colors+for+men&prds=eto:17507790626534216032_0,pid:4082458792858098629&sa=X&ved=0ahUKEwjI5LOby8KKAxWxka8BHWZcChcQ8gIIpwkoAA\",\r\n    \"color_recommendations_search_engine_query_result3_image_url\": \"https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcRZKD90R4PYDz4dYhms-W-nCuvhhFfm49ywVblZHKLd3xjwaWpNuuOsEmTauxvsRQ8w0Q2i8wP2Ba-1_3tEd92004HtNO7_FQ&usqp=CAY\",\r\n    \"color_recommendations_search_engine_query_result3_buy_now_url\": \"https://www.google.com/url?q=http://www.flipkart.com/lovingvibe-creation-men-solid-formal-light-blue-shirt/p/itm04fa998055664%3Fpid%3DSHTHYF8KZ9MY3JNE%26lid%3DLSTSHTHYF8KZ9MY3JNEQY72WJ%26marketplace%3DFLIPKART%26cmpid%3Dcontent_shirt_8965229628_gmc&opi=95576897&sa=U&ved=0ahUKEwjo96Wdy8KKAxXed2wGHZsrLZoQ1ykIFQ&usg=AOvVaw3Q_VV7gfTR5A2Pv4qdkzP7\",\r\n    \"color_recommendations_search_engine_query_result4_title\": \"Sky Blue Cotton Blend Full Sleeve Shirt for Men\",\r\n    \"color_recommendations_search_engine_query_result4_price\": \"₹699.00\",\r\n    \"color_recommendations_search_engine_query_result4_url\": \"https://www.google.com/shopping/product/14219444235294052627?hl=en&q=sky+tone+colors+for+men&prds=eto:17778939369849615517_0,pid:6440307086340256532&sa=X&ved=0ahUKEwjI5LOby8KKAxWxka8BHWZcChcQ8gIIvgkoAA\",\r\n    \"color_recommendations_search_engine_query_result4_image_url\": \"https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcS8A7SCBjPJMvLgegip8Ttar7Fx6WCh0fN5nNVUxC0VySJf79BMu8RXegfd8OzRy0PcTp2ZWf5cL-eGCY3vmDBPKnQTW358kXCXHkNkp6U_Llyk6tWCyAw8-w&usqp=CAY\",\r\n    \"color_recommendations_search_engine_query_result4_buy_now_url\": \"https://www.google.com/url?q=https://jennyfashion.shopdeck.com/Sky-Blue-Cotton-Blend-Full-Sleeve-Shirt-for-Men/catalogue/ZChKBTEZ/fehsOSDn&opi=95576897&sa=U&ved=0ahUKEwjkuNedy8KKAxUqSWwGHXsnJ7YQ1ykIFQ&usg=AOvVaw0RsnXBL2F5HxaiUk4koFey\",\r\n    \"color_recommendations_search_engine_query_result5_title\": \"Sky Blue Stylish Mens Full Sleeves Shirt L\",\r\n    \"color_recommendations_search_engine_query_result5_price\": \"₹899.00\",\r\n    \"color_recommendations_search_engine_query_result5_url\": \"https://www.google.com/shopping/product/15036230054430125740?hl=en&q=sky+tone+colors+for+men&prds=eto:15072877479468676154_0,pid:2806465765449016059&sa=X&ved=0ahUKEwjI5LOby8KKAxWxka8BHWZcChcQ8gIIyQkoAA\",\r\n    \"color_recommendations_search_engine_query_result5_image_url\": \"https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcTAHgc1WdYqAukQcgQ8c417uVDbMtDCOVhx2nojUEwkwNi4x2USwMWCUHidXX37uwrcDFTd8Cf_8ByVVUdDzDzlMPY_mnp9Mw&usqp=CAY\",\r\n    \"color_recommendations_search_engine_query_result5_buy_now_url\": \"https://www.google.com/url?q=https://quyastyle.com/products/stylish-thehorn-mens-full-sleeves-solid-shirt-2%3Fvariant%3D44964876681471%26country%3DIN%26currency%3DINR%26utm_medium%3Dproduct_sync%26utm_source%3Dgoogle%26utm_content%3Dsag_organic%26utm_campaign%3Dsag_organic%26srsltid%3DAfmBOoqfILYS0a5DPIlybOVNsXTEn2JTiNQm4KUjXljhFKayKkP11sMoRzw%26com_cvv%3Dd30042528f072ba8a22b19c81250437cd47a2f30330f0ed03551c4efdaf3409e&opi=95576897&sa=U&ved=0ahUKEwjvz4Wey8KKAxU4dmwGHXsqGmgQ1ykIFQ&usg=AOvVaw3KxgMswQZvq8UPuVBrYAXN\"\r\n}\r\n";
        //public string jsonresult { get; set; }
        public Form3()
        {
            InitializeComponent();
            HideNav();
            showLastLogin();
            LoadImageFromDatabase();
            //LoadImageFromPath(destinationPath);
            LoadProfileFromDatabase();
            HideMeasurements();
            HideProdRecom();
            //LoadImage();
            //LoadImageAsync1();

        }

        private async void LoadImageAsync()
        {
            string url = "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcQuGV6tnt1wxfIqqFQ4R94lKM2PuBji5Dq20I_rACIPzfZj2dw2t1rbP1lO0f1rpFOCcRLHuU57rqdIUyL_IouJ3sgjzmIRlg&usqp=CAY.webp";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Add a User-Agent header (optional for certain URLs)
                    client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

                    // Fetch the image data
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    // Validate Content-Type
                    string contentType = response.Content.Headers.ContentType.MediaType;
                    if (!contentType.StartsWith("image"))
                    {
                        MessageBox.Show($"Invalid Content-Type: {contentType}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Read the image as a stream
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        imgcard1.Image = Image.FromStream(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void LoadImage()
        {
            //string imageUrl = "https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcQuGV6tnt1wxfIqqFQ4R94lKM2PuBji5Dq20I_rACIPzfZj2dw2t1rbP1lO0f1rpFOCcRLHuU57rqdIUyL_IouJ3sgjzmIRlg&usqp=CAY\",\r\n    \"top_wear_search_engine_query_result3_buy_now_url\": \"https://www.google.com/url?q=http://www.myntra.com/Shirts/Roadster/Roadster-Men-Grey-Solid-Regular-Fit-Pure-Cotton-Casual-Shirt/15557630/buy&opi=95576897&sa=U&ved=0ahUKEwjQ3LaSy8KKAxV9SWwGHSanGGsQ1ykIFQ&usg=AOvVaw1cG_xwMTIsS_ahK-enWfuE";

            //using (WebClient webClient = new WebClient())
            //{
            //    try
            //    {
            //        // Download image as a byte array
            //        byte[] imageBytes = webClient.DownloadData(imageUrl);

            //        // Convert byte array to image
            //        using (var stream = new System.IO.MemoryStream(imageBytes))
            //        {
            //            imgcard1.Image = Image.FromStream(stream);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Error loading image: " + ex.Message);
            //    }
            //}

            imgcard1.Load("https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcTeSqsElF4HGb8InLOmOmAh7G9Ga3szXvObStMpfrb1RXBG5SDEYky0NTb43jd2yyfpVuJfY-O-Mav6rpJCfbEPWbII3-ubUBIUxB515BMH");
        }

        private void HideMeasurements() => panel_mhidden.Visible = false;
        private void ShowMeasurements() => panel_mhidden.Visible = panel_mhidden.Visible == false ? true : false;

        private void HideProdRecom() => panel_productrecomm.Visible = false;

        private void ShowProdRecom() => panel_productrecomm.Visible = panel_productrecomm.Visible == false ? true : false;

        private void HideNav()
        {
            panel_hidden.Visible = true;

        }

        private void showLastLogin()
        {
            label_usernameses.Text = UserSession.Username;
        }

        //Application Exit


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (panel_hidden.Visible == false)
            {
                panel_hidden.Visible = true;
                this.Size = new Size(1400, 800);
            }
            else
            {
                panel_hidden.Visible = false;
                this.Size = new Size(1240, 800);
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            UserSession.ClearSession();
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserSession.ClearSession();
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        /*private void LoadImageFromPath(string imagePath)
        {
            try
            {
                // Check if the image path is valid
                if (!string.IsNullOrEmpty(destinationPath) && File.Exists(destinationPath))
                {
                    // Load the image from the specified path
                    Image image = Image.FromFile(destinationPath);

                    // Set the image to the PictureBox
                    image = CorrectImageOrientation(image);
                    pictureBox4.Image = image;

                    // Optionally, you can adjust the PictureBox size mode if needed
                    pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage; // or other modes like AutoSize, CenterImage, etc.
                }
                else
                {
                    MessageBox.Show("The specified image path is invalid or the file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur while loading the image
                MessageBox.Show($"An error occurred while loading the image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        private void LoadImageFromDatabase()
        {
            string connectionString = "Data Source=styleforge-ms-sql-server.ch0q4qge64ch.eu-north-1.rds.amazonaws.com;Initial Catalog=StyleForgeDB;Persist Security Info=True;User ID=admin;Password=StyleForge#123;Trust Server Certificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT FullBodyBin FROM Users WHERE Username = @Username";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", UserSession.Username);

                    object result = cmd.ExecuteScalar(); // Get the image data

                    if (result != DBNull.Value && result is byte[] imageBytes)
                    {
                        using (MemoryStream ms = new MemoryStream(imageBytes))
                        {
                            Image img = Image.FromStream(ms);

                            // Fix the rotation using EXIF metadata
                            img = CorrectImageOrientation(img);

                            pictureBox4.Image = img;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No profile picture found or data is NULL.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while loading the image: " + ex.Message);
                }
            }
        }

        // Corrects the image orientation based on EXIF data
        private Image CorrectImageOrientation(Image img)
        {
            if (img.PropertyIdList.Contains(0x0112)) // 0x0112 = PropertyTagOrientation
            {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                int orientation = img.GetPropertyItem(0x0112).Value[0];
#pragma warning restore CS8602 // Dereference of a possibly null reference.

                switch (orientation)
                {
                    case 3: // Rotate 180
                        img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        break;
                    case 6: // Rotate 90 clockwise
                        img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                        break;
                    case 8: // Rotate 90 counterclockwise
                        img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        break;
                }

                // Remove the orientation property to prevent future issues
                img.RemovePropertyItem(0x0112);
            }

            return img;
        }


        private void LoadProfileFromDatabase()
        {
            byte[] imageBytes = ExecuteDatabaseQuery("SELECT ProfilePicture FROM Users WHERE Username = @Username");

            if (imageBytes != null)
            {
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    Image profileimg = Image.FromStream(ms);
                    profileimg = CorrectImageOrientation(profileimg);
                    profile.Image = profileimg;
                }
            }
            else
            {
                MessageBox.Show("No profile picture found.");
            }
        }


        private byte[] ExecuteDatabaseQuery(string query)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", UserSession.Username);

                    return cmd.ExecuteScalar() as byte[];
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return null;
                }
            }
        }
        private string LoadImageUrlFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 ImageUrl FROM UserImages WHERE UserID = @UserID ORDER BY KeyID DESC", conn);
                    cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);

                    imageUrl = cmd.ExecuteScalar() as string;

                    if (!string.IsNullOrEmpty(imageUrl))
                    {
                        // Load and display the image from the URL
                        //DisplayImageFromUrl(imageUrl);
                        //MessageBox.Show(imageUrl);
                    }
                    else
                    {
                        MessageBox.Show("No image URL found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return imageUrl;
        }



        /*//public string jsonresult;

        //private async void CallMeasurementEngineApi()
        //{
        //    try
        //    {
        //        // Fetch the image URL from your database
        //        string fetchedImageUrl = LoadImageUrlFromDatabase();

        //        string apikey = "fw_3Zm3kcX4SQ3d5GKexgtRdrvW";

        //        // Prepare the JSON payload
        //        var payload = new
        //        {
        //            image_url = fetchedImageUrl,
        //            api_key = apikey
        //        };

        //        string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

        //        // Send the request to the API
        //        using (HttpClient client = new HttpClient())
        //        {
        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        //            HttpResponseMessage response = await client.PostAsync("https://styleforge-measurement-engine-api-v1-168486608630.asia-south1.run.app/measurement-engine-api", content);
        //            string jsonResponse = await response.Content.ReadAsStringAsync();
        //            jsonresult = jsonResponse;

        //            Debug.WriteLine(jsonresult);

        //            // Parse the JSON response dynamically
        //            var jsonObject = JObject.Parse(jsonResponse);

        //            if (jsonObject["status"]?.ToString() == "success")
        //            {
        //                var data = jsonObject["data"];

        //                if (data != null)
        //                {
        //                    // Store values in UserSession
        //                    UserSession.SubjectHeight = data["subject-height"]?.ToString();
        //                    UserSession.SubjectShoulder = data["subject-shoulder"]?.ToString();
        //                    UserSession.SubjectChest = data["subject-chest"]?.ToString();
        //                    UserSession.SubjectWaist = data["subject-waist"]?.ToString();
        //                    UserSession.SubjectHip = data["subject-hip"]?.ToString();
        //                    UserSession.SubjectArm = data["subject-arm"]?.ToString();
        //                    UserSession.WaistToHipRatio = data["waist-to-hip-ratio"]?.ToString();

        //                    // Populate the text boxes with the values
        //                    label_height.Text = UserSession.SubjectHeight;
        //                    label_shoulder.Text = UserSession.SubjectShoulder;
        //                    label_chest.Text = UserSession.SubjectChest;
        //                    label_waist.Text = UserSession.SubjectWaist;
        //                    label_hip.Text = UserSession.SubjectHip;
        //                    label_arm.Text = UserSession.SubjectArm;
        //                    label_ratio.Text = UserSession.WaistToHipRatio;

        //                    // Save measurements to the database with override logic
        //                    using (SqlConnection conn = new SqlConnection(connectionString))
        //                    {
        //                        conn.Open();

        //                        // Check if the user already has a record in the table
        //                        SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM UserMeasurements WHERE UserID = @UserID", conn);
        //                        checkCmd.Parameters.AddWithValue("@UserID", UserSession.UserID);

        //                        int recordCount = (int)checkCmd.ExecuteScalar();

        //                        if (recordCount > 0)
        //                        {
        //                            // Update existing record
        //                            SqlCommand updateCmd = new SqlCommand(@"
        //                            UPDATE UserMeasurements
        //                            SET 
        //                                Height = @Height,
        //                                Shoulder = @Shoulder,
        //                                Chest = @Chest,
        //                                Waist = @Waist,
        //                                Hip = @Hip,
        //                                Arm = @Arm,
        //                                WaistToHipRatio = @WaistToHipRatio,
        //                                MeasurementDate = GETDATE()
        //                            WHERE UserID = @UserID", conn);

        //                            updateCmd.Parameters.AddWithValue("@UserID", UserSession.UserID);
        //                            updateCmd.Parameters.AddWithValue("@Height", UserSession.SubjectHeight);
        //                            updateCmd.Parameters.AddWithValue("@Shoulder", UserSession.SubjectShoulder);
        //                            updateCmd.Parameters.AddWithValue("@Chest", UserSession.SubjectChest);
        //                            updateCmd.Parameters.AddWithValue("@Waist", UserSession.SubjectWaist);
        //                            updateCmd.Parameters.AddWithValue("@Hip", UserSession.SubjectHip);
        //                            updateCmd.Parameters.AddWithValue("@Arm", UserSession.SubjectArm);
        //                            updateCmd.Parameters.AddWithValue("@WaistToHipRatio", UserSession.WaistToHipRatio);

        //                            updateCmd.ExecuteNonQuery();
        //                        }
        //                        else
        //                        {
        //                            // Insert new record
        //                            SqlCommand insertCmd = new SqlCommand(@"
        //                            INSERT INTO UserMeasurements (UserID, Height, Shoulder, Chest, Waist, Hip, Arm, WaistToHipRatio)
        //                            VALUES (@UserID, @Height, @Shoulder, @Chest, @Waist, @Hip, @Arm, @WaistToHipRatio)", conn);

        //                            insertCmd.Parameters.AddWithValue("@UserID", UserSession.UserID);
        //                            insertCmd.Parameters.AddWithValue("@Height", UserSession.SubjectHeight);
        //                            insertCmd.Parameters.AddWithValue("@Shoulder", UserSession.SubjectShoulder);
        //                            insertCmd.Parameters.AddWithValue("@Chest", UserSession.SubjectChest);
        //                            insertCmd.Parameters.AddWithValue("@Waist", UserSession.SubjectWaist);
        //                            insertCmd.Parameters.AddWithValue("@Hip", UserSession.SubjectHip);
        //                            insertCmd.Parameters.AddWithValue("@Arm", UserSession.SubjectArm);
        //                            insertCmd.Parameters.AddWithValue("@WaistToHipRatio", UserSession.WaistToHipRatio);

        //                            insertCmd.ExecuteNonQuery();
        //                        }
        //                    }

        //                    MessageBox.Show("Measurements extracted and saved! See Dashboard for results.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    ShowMeasurements();
        //                }
        //                else
        //                {
        //                    MessageBox.Show("No measurement data found in the response.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Failed to extract measurements. Please check the response or API key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error calling API: " + ex.Message);
        //    }
        //}*/




        public string formattedOutput;
        private void FetchMeasurements()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // SQL query to fetch user measurements based on UserID
                    SqlCommand cmd = new SqlCommand(@"
                SELECT Height, Shoulder, Chest, Waist, Hip, Arm, WaistToHipRatio
                FROM UserMeasurements
                WHERE UserID = @UserID", conn);

                    // Add parameter for UserID
                    cmd.Parameters.AddWithValue("@UserID", UserSession.UserID);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Extract values from the database
                            double height = Convert.ToDouble(reader["Height"]);
                            double shoulder = Convert.ToDouble(reader["Shoulder"]);
                            double chest = Convert.ToDouble(reader["Chest"]);
                            double waist = Convert.ToDouble(reader["Waist"]);
                            double hip = Convert.ToDouble(reader["Hip"]);
                            double arm = Convert.ToDouble(reader["Arm"]);
                            double waistToHipRatio = Convert.ToDouble(reader["WaistToHipRatio"]);

                            // Format the output string
                            formattedOutput = $"subject-height: {height}, subject-shoulder: {shoulder}, subject-chest: {chest}, subject-waist: {waist}, subject-hip: {hip}, subject-arm: {arm}, waist-to-hip-ratio: {waistToHipRatio}";

                            // Output the formatted string
                            MessageBox.Show(formattedOutput, "Measurements", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Optionally, you can still populate the labels if needed
                            label_height.Text = height.ToString();
                            label_shoulder.Text = shoulder.ToString();
                            label_chest.Text = chest.ToString();
                            label_waist.Text = waist.ToString();
                            label_hip.Text = hip.ToString();
                            label_arm.Text = arm.ToString();
                            label_ratio.Text = waistToHipRatio.ToString();

                            // MessageBox.Show("Measurements successfully loaded from the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("No measurements found for the current user.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }



        //string jsonresult = GlobalSettings.JSONresult;


        /*public static string ParseJsonToSingleString(string jsonString)
        {
            JObject json = JObject.Parse(jsonString);
            JObject data = (JObject)json["data"];

            string result = string.Join(", ", data.Properties().Select(prop => $"{prop.Name}: {prop.Value}"));
            return result;
        }*/

        private async void CallRSEQApi()
        {
            string apikey = "fw_3Zm3kcX4SQ3d5GKexgtRdrvW";
            string jsonrseq = "| **Height Range** | **Tops** | **Bottoms** | **Shoes** | **Accessories** | **Color Sense** | |------------------|------------------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------| | **160–167 cm** | - Fitted t-shirts or polo shirts<br>- Vertical stripes or small patterns<br>- Waist-length jackets | - Slim-fit jeans or chinos<br>- Cropped or ankle-length trousers<br>- Darker colors for elongation | - Low-profile sneakers<br>- Chelsea boots with slight heels<br>- Minimalist designs | - Slim belts<br>- Medium-sized bags<br>- Sleek caps or beanies | - Monochrome outfits<br>- Contrast light tops with dark bottoms for balance | | **167–174 cm** | - Slim-fit or tailored shirts<br>- V-neck sweaters<br>- Layered outfits with proportions | - Tapered or straight-leg pants<br>- Mid-rise trousers<br>- Neutral or solid colors | - Low or mid-profile sneakers<br>- Desert boots or loafers | - Leather belts<br>- Medium-to-small backpacks<br>- Simple watches or bracelets | - Earth tones or muted palettes<br>- Incorporate subtle patterns for variety | | **174–181 cm** | - Casual t-shirts and shirts with added layering<br>- Neutral colors or subtle patterns<br>- Slim jackets | - Straight-leg or slightly relaxed pants<br>- Dark or earthy tones | - Sneakers, loafers, or boots<br>- Avoid overly flat or exaggerated platforms | - Medium-width belts<br>- Messenger bags or crossbody bags<br>- Simple caps | - Neutral tones with bold accent pieces<br>- Dark tops for a slimming effect | | **181–188 cm** | - Slim-fit button-ups<br>- Long-sleeve t-shirts<br>- Tailored blazers for casual events | - Slightly relaxed fit pants<br>- Avoid overly slim styles for balance | - Casual leather sneakers<br>- Brogue boots for added style | - Larger backpacks or shoulder bags<br>- Statement watches | - Classic tones like navy, gray, or white<br>- Use vertical patterns to emphasize height | | **188–195 cm** | - Tailored shirts or turtlenecks<br>- Longline t-shirts or sweaters<br>- Coats ending mid-thigh for balance | - Straight-cut pants<br>- Avoid cropped pants unless paired with boots | - High-top sneakers or boots<br>- Classic leather shoes | - Structured bags<br>- Wider belts for balance<br>- Subtle scarves or accessories | - Deep tones like burgundy, forest green, or charcoal<br>- Avoid overly busy patterns for balance |";

            FetchMeasurements();
            Debug.WriteLine(formattedOutput);

            var payload = new
            {
                api_key = apikey,
                recommendation_table = jsonrseq,
                body_analysis_table = formattedOutput,
            };

            string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://styleforge-rseq-api-v2-168486608630.asia-south1.run.app/rseq-api-v2", content);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(jsonResponse);



                // Parse the JSON response to extract search engine queries
                try
                {
                    var json = JObject.Parse(jsonResponse.Replace("```", "").Trim());
                    string dataString = json["data"].ToString();
                    dataString = dataString.Replace("```", "").Replace("\\n", "\n").Trim();

                    var dataJson = JObject.Parse(dataString);

                    // Extract the search engine queries
                    string topWearQuery = dataJson["top_wear_search_engine_query"]?.ToString();
                    string bottomWearQuery = dataJson["bottom_wear_search_engine_query"]?.ToString();
                    string shoesQuery = dataJson["shoes_search_engine_query"]?.ToString();
                    string colorRecommendationsQuery = dataJson["color_recommendations_search_engine_query"]?.ToString();


                    UserSession.topWearQuery = topWearQuery;
                    UserSession.bottomWearQuery = bottomWearQuery;
                    UserSession.shoesQuery = shoesQuery;
                    UserSession.colorRecommendationsQuery = colorRecommendationsQuery;

                    // Log the queries in the Debug console
                    Debug.WriteLine("Top Wear Query: " + topWearQuery);
                    Debug.WriteLine("Bottom Wear Query: " + bottomWearQuery);
                    Debug.WriteLine("Shoes Query: " + shoesQuery);
                    Debug.WriteLine("Color Recommendations Query: " + colorRecommendationsQuery);

                    // Proceed with extracting text recommendations
                    string textRecommendations = dataJson["text_recommendations"]?.ToString()?.Trim();

                    if (!string.IsNullOrEmpty(textRecommendations))
                    {
                        label_txtrecomm.Text = "Here are your Recommendations!\n\n" + textRecommendations;
                        MessageBox.Show("RSEQ Extracted! See Dashboard for Results", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        label_txtrecomm.Text = "No recommendations found.";
                        MessageBox.Show("No recommendations found in the response.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Newtonsoft.Json.JsonReaderException ex)
                {
                    Debug.WriteLine("Error parsing JSON: " + ex.Message);
                    MessageBox.Show("Failed to parse JSON response. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Unexpected error: " + ex.Message);
                    MessageBox.Show("An unexpected error occurred. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        private void label_showm_Click_1(object sender, EventArgs e)
        {
            FetchMeasurements();
            ShowMeasurements();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            CallRSEQApi();
        }

        private void label_prodrecom_Click(object sender, EventArgs e)
        {
            ShowProdRecom();
        }


        private  static async void CallCrawlerApi()
        {
            string apikey = "fw_3Zm3kcX4SQ3d5GKexgtRdrvW";

            string username = "muralidharacharya7";

            string accesskey = "UUKsq9xWAVEXPH0qkqXBm0QIB6mUUSqYCOwdzSgI0vre2dqEff";

            var payload = new
            {
                LT_USERNAME = username,
                LT_ACCESS_KEY = accesskey,
                top_wear_search_engine_query = UserSession.topWearQuery,
                bottom_wear_search_engine_query = UserSession.bottomWearQuery,
                shoes_search_engine_query = UserSession.shoesQuery,
                color_recommendations_search_engine_query = UserSession.colorRecommendationsQuery,
            };

            string jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent(jsonPayload, System.Text.Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("https://styleforge-rrc-api-v3-168486608630.asia-south1.run.app/rrc-api-v3", content);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(jsonResponse);
                Console.WriteLine(jsonResponse);

                MessageBox.Show(jsonResponse, "JsonResponse", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UserSession.crawlerApiResponse = jsonResponse;
 
            }
        }

        private void CallPythonScript()
        {
            // Set the Python executable path and script path
            string pythonPath = @"C:\Users\mural\AppData\Local\Programs\Python\Python310\python.exe";  // Path to Python
            string scriptPath = @"D:\img_down\imgdown.py";   // Path to your Python script

            try
            {
                // Configure process to hide the command prompt window
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = pythonPath,
                    Arguments = scriptPath,
                    UseShellExecute = false,  // Required to hide window
                    CreateNoWindow = true,    // Don't create a window
                    RedirectStandardOutput = true,  // Capture output
                    RedirectStandardError = true   // Capture errors
                };

                // Start the process
                Process process = Process.Start(processInfo);

                // Capture the output and errors
                string output = process.StandardOutput.ReadToEnd();
                string errors = process.StandardError.ReadToEnd();

                // Wait for the script to finish
                process.WaitForExit();

                // Check if the script ran successfully (ExitCode 0 means success)
                if (process.ExitCode == 0)
                {
                    Console.WriteLine("Python script executed successfully!");
                    Console.WriteLine("Output:");
                    Console.WriteLine(output);
                }
                else
                {
                    Console.WriteLine("Python script failed!");
                    Console.WriteLine("Errors:");
                    Console.WriteLine(errors);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        private void DisplayApiResponse()
        {
            

            try
            {
                var json = JObject.Parse(jsonRes);

                // Extract the search engine queries
                imgcard1.Load(@"D:\img_down\outputs\top_wear_search_engine_query_result1_image.jpg");
                string title1 = json["top_wear_search_engine_query_result1_title"]?.ToString();
                string price1 = json["top_wear_search_engine_query_result1_price"]?.ToString();   
                string buyNow1 = json["top_wear_search_engine_query_result1_buy_now_url"]?.ToString();

                imgcard2.Load(@"D:\img_down\outputs\top_wear_search_engine_query_result2_image.jpg");
                string title2 = json["top_wear_search_engine_query_result2_title"]?.ToString();
                string price2 = json["top_wear_search_engine_query_result2_price"]?.ToString();
                string buyNow2 = json["top_wear_search_engine_query_result2_buy_now_url"]?.ToString();

                imgcard3.Load(@"D:\img_down\outputs\top_wear_search_engine_query_result3_image.jpg");
                string title3 = json["top_wear_search_engine_query_result3_title"]?.ToString();
                string price3 = json["top_wear_search_engine_query_result3_price"]?.ToString();
                string buyNow3 = json["top_wear_search_engine_query_result3_buy_now_url"]?.ToString();

                imgcard4.Load(@"D:\img_down\outputs\top_wear_search_engine_query_result4_image.jpg");
                string title4 = json["top_wear_search_engine_query_result4_title"]?.ToString();
                string price4 = json["top_wear_search_engine_query_result4_price"]?.ToString();
                string buyNow4 = json["top_wear_search_engine_query_result4_buy_now_url"]?.ToString();

                imgcard5.Load(@"D:\img_down\outputs\top_wear_search_engine_query_result5_image.jpg");
                string title5 = json["top_wear_search_engine_query_result5_title"]?.ToString();
                string price5 = json["top_wear_search_engine_query_result5_price"]?.ToString();
                string buyNow5 = json["top_wear_search_engine_query_result5_buy_now_url"]?.ToString();


                btnTitle1.Text = title1;
                btnPrice1.Text = price1;
                btnBuy1.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow1) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle2.Text = title2;
                btnPrice2.Text = price2;
                btnBuy2.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow2) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle3.Text = title3;
                btnPrice3.Text = price3;
                btnBuy3.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow3) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle4.Text = title4;
                btnPrice4.Text = price4;
                btnBuy4.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow4) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle5.Text = title5;
                btnPrice5.Text = price5;
                btnBuy5.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow5) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };


                //// Log the queries in the Debug console
                //Debug.WriteLine("Top Wear Query: " + topWearQuery);
                //Debug.WriteLine("Bottom Wear Query: " + bottomWearQuery);
                //Debug.WriteLine("Shoes Query: " + shoesQuery);
                //Debug.WriteLine("Color Recommendations Query: " + colorRecommendationsQuery);

                //// Proceed with extracting text recommendations
                //string textRecommendations = dataJson["text_recommendations"]?.ToString()?.Trim();

                //if (!string.IsNullOrEmpty(textRecommendations))
                //{
                //    label_txtrecomm.Text = "Here are your Recommendations!\n\n" + textRecommendations;
                //    MessageBox.Show("RSEQ Extracted! See Dashboard for Results", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    label_txtrecomm.Text = "No recommendations found.";
                //    MessageBox.Show("No recommendations found in the response.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Newtonsoft.Json.JsonReaderException ex)
            {
                Debug.WriteLine("Error parsing JSON: " + ex.Message);
                MessageBox.Show("Failed to parse JSON response. Please try again later.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unexpected error: " + ex.Message);
                MessageBox.Show("An unexpected error occurred. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnShowRecomProd_Click(object sender, EventArgs e)
        {
            //CallCrawlerApi();
            DisplayApiResponse();
            //CallPythonScript();
        }
    }
}
