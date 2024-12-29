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



        public string jsonRes = "{\"top_wear_search_engine_query_result1_title\":\"American Eagle Men Red Slim Fit Solid Oxford Button-Up Shirt , Size XXL\",\"top_wear_search_engine_query_result1_price\":\"₹2,100.00\",\"top_wear_search_engine_query_result1_url\":\"https://www.google.com/shopping/product/199436831548974740?hl=en&q=slim+fit+button+ups+for+men&prds=eto:12783268908045526243_0,pid:985193547006074917&sa=X&ved=0ahUKEwij7JyGrMqKAxXOg68BHRfwBDsQ8gII-w0oAA\",\"top_wear_search_engine_query_result1_image_url\":\"https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcSgnq1GZy5CE8dlAyXdAdItCRCmsFDBXdpT4C2RpqibHOM5lA7Ggm9BWLKoU0QGAGcdCU19z7UMQDG1dvt3dY5frAvZlwWk&usqp=CAY\",\"top_wear_search_engine_query_result1_buy_now_url\":\"https://www.google.com/url?q=https://www.nykaafashion.com/american-eagle-men-pink-slim-fit-solid-oxford-button-up-shirt/p/16297410%3Fadsource%3Dshopping_india%26skuId%3D16295153%26srsltid%3DAfmBOorZd_RYr9B6q01X_TCs8yR5d_Fbi_LFvdYFgNgFbvmtPjFVgicV1Gc&opi=95576897&sa=U&ved=0ahUKEwiJ-b-HrMqKAxUmVmwGHXCbGg4Q1ykIFQ&usg=AOvVaw0ebzyvuWLb57HtABRW89LB\",\"top_wear_search_engine_query_result2_title\":\"Roadster Men Grey Solid Slim Fit Casual Shirt (44) by Myntra\",\"top_wear_search_engine_query_result2_price\":\"₹639.00\",\"top_wear_search_engine_query_result2_url\":\"https://www.google.com/shopping/product/3717590986764891420?hl=en&q=slim+fit+button+ups+for+men&prds=eto:2993064045576226180_0,pid:17211263966575735155&sa=X&ved=0ahUKEwij7JyGrMqKAxXOg68BHRfwBDsQ8gIIng4oAA\",\"top_wear_search_engine_query_result2_image_url\":\"https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcR_cDLsMgCthZGbaa8whdTKY2XPUrhq8fmr0yUKEBe3da0DDgfO06Ewf9PEr5NDIhWqG9rHKQgf4xZzQCBE6fn1F1p_Zfxe&usqp=CAY\",\"top_wear_search_engine_query_result2_buy_now_url\":\"https://www.google.com/url?q=http://www.myntra.com/Shirts/Roadster/Roadster-Men-Grey-Solid-Slim-Fit-Casual-Shirt/14641376/buy&opi=95576897&sa=U&ved=0ahUKEwilnpOIrMqKAxWabmwGHahBFzUQ1ykIFQ&usg=AOvVaw25uuIEnX-ueEulBP2vcN18\",\"top_wear_search_engine_query_result3_title\":\"DENNISON Men Smart Spread Collar Textured Party Shirt (42) by Myntra\",\"top_wear_search_engine_query_result3_price\":\"₹674.00\",\"top_wear_search_engine_query_result3_url\":\"https://www.google.com/shopping/product/5813361484792143100?hl=en&q=slim+fit+button+ups+for+men&prds=eto:7722123846429448778_0,pid:13744919957313631541,rsk:PC_1716532085210645232&sa=X&ved=0ahUKEwij7JyGrMqKAxXOg68BHRfwBDsQ8gII5A0oAA\",\"top_wear_search_engine_query_result3_image_url\":\"https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcQJCaTRoQhS3ga1ocvhGkLnaJiaSWaZSpqHdOZrB-dhh-jYiM9_D_bW8pnvY3Jm6tGjkn2d3_e2Q4_G4GuFTqnkE3xaGd09zg&usqp=CAY\",\"top_wear_search_engine_query_result3_buy_now_url\":\"https://www.google.com/url?q=http://www.myntra.com/Shirts/DENNISON/DENNISON-Men-Smart-Spread-Collar-Textured-Party-Shirt/30636306/buy&opi=95576897&sa=U&ved=0ahUKEwjR3NWIrMqKAxVLTmwGHUxaPdAQ1ykIFQ&usg=AOvVaw3GT4T2gyLMk7BqSLP3fUSq\",\"top_wear_search_engine_query_result4_title\":\"Pinkmint Mens Long Sleeve Button Down Shirt for Men Collared Casual Formal Soild Shirt\",\"top_wear_search_engine_query_result4_price\":\"₹379.00\",\"top_wear_search_engine_query_result4_url\":\"https://www.google.com/shopping/product/7796104796241954626?hl=en&q=slim+fit+button+ups+for+men&prds=eto:4225591669643061131_0,pid:7715325973103985909&sa=X&ved=0ahUKEwij7JyGrMqKAxXOg68BHRfwBDsQ8gII8A0oAA\",\"top_wear_search_engine_query_result4_image_url\":\"https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcTcDiuKFmrSVzj2AFljt8y8o_rlHGWD9P8IjG8o2nfYgs2cussUspkUUYdsPJZLFduXJdvaUboLKBFp8UfxIPg3nNI9-KYY&usqp=CAY\",\"top_wear_search_engine_query_result4_buy_now_url\":\"https://www.google.com/url?q=https://www.amazon.in/Pinkmint-Sleeve-Button-Collared-Casual/dp/B0CW1WK7WQ%3Fsource%3Dps-sl-shoppingads-lpcontext%26ref_%3Dfplfs%26psc%3D1%26smid%3DA1WYWER0W24N8S&opi=95576897&sa=U&ved=0ahUKEwjPpsCJrMqKAxVVTWwGHTrlAJUQ1ykIFQ&usg=AOvVaw3doK_65nZtBzow60I3CREe\",\"top_wear_search_engine_query_result5_title\":\"Men Beige Solid Cotton Linen Shirt - L\",\"top_wear_search_engine_query_result5_price\":\"₹899.00\",\"top_wear_search_engine_query_result5_url\":\"https://www.google.com/shopping/product/11846522403196951940?hl=en&q=slim+fit+button+ups+for+men&prds=eto:4773985738103110510_0,pid:13649644721816688548,rsk:PC_3859696770463260684&sa=X&ved=0ahUKEwij7JyGrMqKAxXOg68BHRfwBDsQ8gIIkg4oAA\",\"top_wear_search_engine_query_result5_image_url\":\"https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcQZeFShIPCcBAG8TAGluW7pbZciVRaL5k0EEKJ6f8X26QgldxLm6nlpOu_Xq2Jb1nBu56tY5Svh1PNTltgALr5eEG9l4C-F&usqp=CAY\",\"top_wear_search_engine_query_result5_buy_now_url\":\"https://www.google.com/url?q=http://www.myntra.com/Shirts/Thomas%2BScott/Thomas-Scott-Premium-Cotton-Linen-Slim-Fit-Opaque-Casual-Shirt/28592488/buy&opi=95576897&sa=U&ved=0ahUKEwjV7fmJrMqKAxVRUGwGHV8YBGcQ1ykIFQ&usg=AOvVaw2d8akdGwoEnfP2kDEzhr9V\",\"bottom_wear_search_engine_query_result1_title\":\"Off Duty | Korean Baggy Loose Fit Pants For Men Cream / S-30\",\"bottom_wear_search_engine_query_result1_price\":\"₹1,699.00\",\"bottom_wear_search_engine_query_result1_url\":\"https://www.google.com/shopping/product/16038550850118993066?hl=en&q=slightly+relaxed+fit+pants+for+men&prds=eto:6717676809771338980_0,pid:16611582462616122071&sa=X&ved=0ahUKEwjo5eiKrMqKAxUabPUHHQjXJg0Q8gII8wsoAA\",\"bottom_wear_search_engine_query_result1_image_url\":\"https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcS-Zasi76Er33eb0ehyml7plHMBuVLBAokYGnlQfUJ-X0hGKrKMzkVAvy6zP89C3AzoMwqSZ3q6gBFM1xAiYywf8_l_TQxf&usqp=CAY\",\"bottom_wear_search_engine_query_result1_buy_now_url\":\"https://www.google.com/url?q=https://offduty.in/products/korean-baggy-loose-fit-pants-for-men-new%3Fvariant%3D41897622601825%26country%3DIN%26currency%3DINR%26utm_medium%3Dproduct_sync%26utm_source%3Dgoogle%26utm_content%3Dsag_organic%26utm_campaign%3Dsag_organic%26srsltid%3DAfmBOoqCGsAcc_FwA0Ew5ToNq7McbNta1Oa2H-pV9FlDOJsg3LzLtgXZEt0&opi=95576897&sa=U&ved=0ahUKEwj7l4qMrMqKAxUNT2wGHZDUHL0Q1ykIFQ&usg=AOvVaw1ULPsfunZW-ztTXStRd11n\",\"bottom_wear_search_engine_query_result2_title\":\"The Roadster Lifestyle Co Men Loose Fit Trousers (28) by Myntra\",\"bottom_wear_search_engine_query_result2_price\":\"₹969.00\",\"bottom_wear_search_engine_query_result2_url\":\"https://www.google.com/shopping/product/14243974408961080987?hl=en&q=slightly+relaxed+fit+pants+for+men&prds=eto:16852029777796404551_0,pid:5207985365961308499&sa=X&ved=0ahUKEwjo5eiKrMqKAxUabPUHHQjXJg0Q8gIImAwoAA\",\"bottom_wear_search_engine_query_result2_image_url\":\"https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcS6kqmTMMsGiElKkXw_-idaVj_ZyDijES5OyjBhMOnO9nazHLJN5uTAGTvt67P4Kc9XObFazLiBmvMUEM8-G3nV4Uh3o9i1&usqp=CAY\",\"bottom_wear_search_engine_query_result2_buy_now_url\":\"https://www.google.com/url?q=http://www.myntra.com/Trousers/Roadster/The-Roadster-Lifestyle-Co-Men-Loose-Fit-Trousers/31648488/buy&opi=95576897&sa=U&ved=0ahUKEwjc1POMrMqKAxU_TGwGHdy2KhIQ1ykIFQ&usg=AOvVaw1_L5JeK_5BNaHuB6TVNDe4\",\"bottom_wear_search_engine_query_result3_title\":\"FTX Men Relaxed Fit Trousers with Insert Pockets For Men (Olive, 32)\",\"bottom_wear_search_engine_query_result3_price\":\"₹485.00\",\"bottom_wear_search_engine_query_result3_url\":\"https://www.google.com/shopping/product/3285087858097819265?hl=en&q=slightly+relaxed+fit+pants+for+men&prds=eto:2424095968147786038_0,pid:11825357859181702100&sa=X&ved=0ahUKEwjo5eiKrMqKAxUabPUHHQjXJg0Q8gII6AsoAA\",\"bottom_wear_search_engine_query_result3_image_url\":\"https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcQKlgaJlU_bnvFNQiSBV9Z5Qj7iDOj6pni5M8Tv9yOB3d8BXVF2zmu45ivO6tlaUXEgTaP2poPcCERN32gIYFQ37fKe_gMJ&usqp=CAY\",\"bottom_wear_search_engine_query_result3_buy_now_url\":\"https://www.google.com/url?q=https://www.ajio.com/ftx-men-relaxed-fit-trousers-with-insert-pockets/p/700535450_olive%3Fsrsltid%3DAfmBOoporde5WWYs73Umsyba6eIJGVhIU1b_GNdaAr2YAZE1f96iDAj2lzY%23gmf&opi=95576897&sa=U&ved=0ahUKEwjZx7yNrMqKAxW7XmwGHfd0DQoQ1ykIGQ&usg=AOvVaw2vQBUXuEKDOzDMyXrx-wnx\",\"bottom_wear_search_engine_query_result4_title\":\"YOUSTA Men Relaxed Fit Flat-Front Pants with Insert Pockets For Men (Beige, 34)\",\"bottom_wear_search_engine_query_result4_price\":\"₹799.00\",\"bottom_wear_search_engine_query_result4_url\":\"https://www.google.com/shopping/product/16423771700943739894?hl=en&q=slightly+relaxed+fit+pants+for+men&prds=eto:1738698510474097013_0,pid:8230940192708926463&sa=X&ved=0ahUKEwjo5eiKrMqKAxUabPUHHQjXJg0Q8gIIjQwoAA\",\"bottom_wear_search_engine_query_result4_image_url\":\"https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcRdsmLRp4kCXQnLxwGoEWeJbwsnoYpQhfhmvDiOY8ZUPP4X_y7ZZMsjJ-ZuRD6Q8VDUd9TpVtYf9b1iQhJcPMuC_WBZwWcMpg&usqp=CAY\",\"bottom_wear_search_engine_query_result4_buy_now_url\":\"https://www.google.com/url?q=https://www.ajio.com/yousta-men-relaxed-fit-flat-front-pants-with-insert-pockets/p/442664591_beige%3Fsrsltid%3DAfmBOoraoo1P7FFEjLv9JTWUGQfHsIQzQNICxSB6PEoMY-mGmn7sFLwSf08%23gmf&opi=95576897&sa=U&ved=0ahUKEwi61viNrMqKAxVUUGcHHVpRCSAQ1ykIGQ&usg=AOvVaw335AoITpNhYsuC01sonFP1\",\"bottom_wear_search_engine_query_result5_title\":\"The Roadster Lifestyle Co Men Relaxed Fit Trousers (32) by Myntra\",\"bottom_wear_search_engine_query_result5_price\":\"₹979.00\",\"bottom_wear_search_engine_query_result5_url\":\"https://www.google.com/shopping/product/16153209439070881138?hl=en&q=slightly+relaxed+fit+pants+for+men&prds=eto:2107311762190974341_0,pid:18305644035165060327&sa=X&ved=0ahUKEwjo5eiKrMqKAxUabPUHHQjXJg0Q8gII_gsoAA\",\"bottom_wear_search_engine_query_result5_image_url\":\"https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcSFytJz4zYBl59FdwplxLvLAL5a9a6sXunvVT8sxkKGQVPBj7kev1UMfdNirf7cnQaXZzUX_mhOqEbzIaGHtOrb0iGXTYTH&usqp=CAY\",\"bottom_wear_search_engine_query_result5_buy_now_url\":\"https://www.google.com/url?q=http://www.myntra.com/Trousers/Roadster/The-Roadster-Lifestyle-Co-Men-Relaxed-Fit-Trousers/31540314/buy&opi=95576897&sa=U&ved=0ahUKEwib1beOrMqKAxWYUGwGHZ-SN6oQ1ykIFQ&usg=AOvVaw1tXcgwGtoA9yRXEnVhi1XF\",\"shoes_search_engine_query_result1_title\":\"MICHAEL ANGELO Men Lace-Up Sneakers with Round-Toe For Men (Black, 11)\",\"shoes_search_engine_query_result1_price\":\"₹1,080.00\",\"shoes_search_engine_query_result1_url\":\"https://www.google.com/shopping/product/7460339884432380556?hl=en&q=casual+leather+sneakers+for+men&prds=eto:15944169285410589738_0,pid:10298398393743981676&sa=X&ved=0ahUKEwi9yYGPrMqKAxUXUfUHHei_CxwQ8gIIqQ4oAA\",\"shoes_search_engine_query_result1_image_url\":\"https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcQSWTCwVH3otEGTe-yuf4J02MMlZejg3eVXVTwZATf05h2DoOGe4DxTlDuIy2qKfSNC7j5TM-oZno1jiZ6G-5J0gjQye6JB&usqp=CAY\",\"shoes_search_engine_query_result1_buy_now_url\":\"https://www.google.com/url?q=https://www.ajio.com/michael-angelo-men-lace-up-sneakers-with-round-toe-/p/466757264_black%3Fsrsltid%3DAfmBOoqPIObbjuJ68z4W8C-cEIx1mhJN3VIksOkaawNMMbdFomFP-yhXfPE%23gmf&opi=95576897&sa=U&ved=0ahUKEwjMtsiQrMqKAxUWe2wGHdojEkUQ1ykIGQ&usg=AOvVaw2TQlIFzAXxylamiKl6SbO6\",\"shoes_search_engine_query_result2_title\":\"RARE RABBIT Men Keith Perforated Leather Sneakers(7) by Myntra\",\"shoes_search_engine_query_result2_price\":\"₹3,000.00\",\"shoes_search_engine_query_result2_url\":\"https://www.google.com/shopping/product/12728986222140531132?hl=en&q=casual+leather+sneakers+for+men&prds=eto:7624596641282223828_0,pid:3578276269028489214,rsk:PC_10058236799255239596&sa=X&ved=0ahUKEwi9yYGPrMqKAxUXUfUHHei_CxwQ8gII0A0oAA\",\"shoes_search_engine_query_result2_image_url\":\"https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcT97XPBMqi8aE_nBZJlt9wZOds2DYnzRujply6BChvn7r2SVjGgNsXaY_CNyreRCH4SDVNdsUWP3RpyDpg3aTiNc4TFnntb&usqp=CAY\",\"shoes_search_engine_query_result2_buy_now_url\":\"https://www.google.com/url?q=http://www.flipkart.com/rare-rabbit-casuals-men/p/itm186fba47fdcac%3Fpid%3DSHOGUHS3WUPV3TY4%26lid%3DLSTSHOGUHS3WUPV3TY40K8TGU%26marketplace%3DFLIPKART%26cmpid%3Dcontent_shoe_8965229628_gmc&opi=95576897&sa=U&ved=0ahUKEwjpwYmRrMqKAxV8SGcHHYhwAAgQ1ykIFQ&usg=AOvVaw3pBi3dtS5C6bW-hemvtaah\",\"shoes_search_engine_query_result3_title\":\"Men’s Tan leather Casual Sneakers– Comfortable & Stylish Everyday Footwear 42\",\"shoes_search_engine_query_result3_price\":\"₹2,190.00\",\"shoes_search_engine_query_result3_url\":\"https://www.google.com/shopping/product/44618563595355228?hl=en&q=casual+leather+sneakers+for+men&prds=eto:7870294200002420647_0,pid:6225915550030748439&sa=X&ved=0ahUKEwi9yYGPrMqKAxUXUfUHHei_CxwQ8gIIzw4oAA\",\"shoes_search_engine_query_result3_image_url\":\"https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcTyteWWy7Ij_-a80HvNNhO9I8-yCujPAcijWut8rkv9rM6SrUpnn-g5aQU9NtiJKJVd_A3F1spKNHMnH3Vm62mN1ZA6pLXJBQ&usqp=CAY\",\"shoes_search_engine_query_result3_buy_now_url\":\"https://www.google.com/url?q=https://punjabshoeco.in/products/casual-shoes%3Fvariant%3D50140349137209%26country%3DIN%26currency%3DINR%26utm_medium%3Dproduct_sync%26utm_source%3Dgoogle%26utm_content%3Dsag_organic%26utm_campaign%3Dsag_organic%26srsltid%3DAfmBOorqOv6tAXR7kPCyybvome_41L6DZP6TLDjI5xPrVPM0dyT2rGvD4Q8%26com_cvv%3Dd30042528f072ba8a22b19c81250437cd47a2f30330f0ed03551c4efdaf3409e&opi=95576897&sa=U&ved=0ahUKEwilwceRrMqKAxV6d2wGHcRWLaQQ1ykIFQ&usg=AOvVaw3Q_nwUFKVbwTvttCetGfu0\",\"shoes_search_engine_query_result4_title\":\"EZOK Men Lace-Ups Leather Antibacterial Sneakers (7) by Myntra\",\"shoes_search_engine_query_result4_price\":\"₹3,150.00\",\"shoes_search_engine_query_result4_url\":\"https://www.google.com/shopping/product/5412997327564749049?hl=en&q=casual+leather+sneakers+for+men&prds=eto:7436638716155276626_0,pid:12101123529422906961&sa=X&ved=0ahUKEwi9yYGPrMqKAxUXUfUHHei_CxwQ8gII2w4oAA\",\"shoes_search_engine_query_result4_image_url\":\"https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcT-q0uwlRMHhWbgKukM_s3Zmecqh7Fov8AGM_ENXav3_eiPRIVkxp4JKr2Q8Lkx6Ur4zcQlf3wR-lxDB1VhPhdp-bzGon8v&usqp=CAY\",\"shoes_search_engine_query_result4_buy_now_url\":\"https://www.google.com/url?q=https://www.nykaafashion.com/ezok-tan-flexi-brogues-for-men/p/17959555%3Fadsource%3Dshopping_india%26skuId%3D17959538%26srsltid%3DAfmBOopI-qUeI_zHFRu3qfrWlu0F0xCIz6wEOAU_kWU6h6evY1W-iF3hnkI&opi=95576897&sa=U&ved=0ahUKEwiB3IKSrMqKAxWWR2wGHcB8E7sQ1ykIFQ&usg=AOvVaw07vHrqODUeYP05HbGPhqVJ\",\"shoes_search_engine_query_result5_title\":\"Monte Carlo Men Round Toe Leather Sneakers (7) by Myntra\",\"shoes_search_engine_query_result5_price\":\"₹3,265.00\",\"shoes_search_engine_query_result5_url\":\"https://www.google.com/shopping/product/6378577103211078174?hl=en&q=casual+leather+sneakers+for+men&prds=eto:14210231269449843148_0,pid:6867468650968002733,rsk:PC_267319061492802429&sa=X&ved=0ahUKEwi9yYGPrMqKAxUXUfUHHei_CxwQ8gIImQ4oAA\",\"shoes_search_engine_query_result5_image_url\":\"https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcRTzJciVW_6U4AemxePEgggMrfM1Qyea8o96l9OcFbsMdlzbN4tcotxzlP5RQR_BGKy_ZeOCZBXNjC-Vt7xqhxHuM-MOFOKLw&usqp=CAY\",\"shoes_search_engine_query_result5_buy_now_url\":\"https://www.google.com/url?q=https://www.amazon.in/Monte-Carlo-Genuine-Leather-201829FW-2-7/dp/B0CWG9TCV1%3Fsource%3Dps-sl-shoppingads-lpcontext%26ref_%3Dfplfs%26psc%3D1%26smid%3DA1WYWER0W24N8S&opi=95576897&sa=U&ved=0ahUKEwjAjcOSrMqKAxVIcGwGHckiEy8Q1ykIFQ&usg=AOvVaw2x0ZpAZUutAzf7vzFUa4zL\",\"color_recommendations_search_engine_query_result1_title\":\"Classic Retro casual Slim Fit Shirt for men\",\"color_recommendations_search_engine_query_result1_price\":\"₹311.00\",\"color_recommendations_search_engine_query_result1_url\":\"https://www.google.com/shopping/product/18100204584963398776?hl=en&q=classic+tone+shirts+for+men&prds=eto:8659874678420115321_0,pid:1545866772560106317&sa=X&ved=0ahUKEwjapPqSrMqKAxVWdfUHHbOeLZIQ8gII1gooAA\",\"color_recommendations_search_engine_query_result1_image_url\":\"https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcSOv_965qOBKXMtEAX7NTf2K59aefc4L2qc-FePZXv8f5ENS8F8pQqxQDOtbefRD2A1E4Ey3UsXoDbCVmjdmc4CZwqUL5qlB3YpcDsaltw&usqp=CAY\",\"color_recommendations_search_engine_query_result1_buy_now_url\":\"https://www.google.com/url?q=https://www.meesho.com/classic-retro-casual-slim-fit-shirt-for-men/p/3uxpvp%3Futm_source%3Dgoogle%26utm_medium%3Dcpc%26utm_campaign%3Dgmc%26srsltid%3DAfmBOop3VCEOlTg-sTr0SXA9cNE97zFv76LntmvpV00nWvAx9DGNlChccLk&opi=95576897&sa=U&ved=0ahUKEwiMm42UrMqKAxWEfGwGHcboIMsQ1ykIFQ&usg=AOvVaw3oJjOKBDrHoRqgORlLzLNT\",\"color_recommendations_search_engine_query_result2_title\":\"Mast & Harbour Beige Classic Slim Fit Casual Cotton Linen Shirt (40) by Myntra\",\"color_recommendations_search_engine_query_result2_price\":\"₹799.00\",\"color_recommendations_search_engine_query_result2_url\":\"https://www.google.com/shopping/product/16657263114343074628?hl=en&q=classic+tone+shirts+for+men&prds=eto:16337242355914768096_0,pid:3039689237592270196,rsk:PC_14229905654753201835&sa=X&ved=0ahUKEwjapPqSrMqKAxVWdfUHHbOeLZIQ8gIIkgooAA\",\"color_recommendations_search_engine_query_result2_image_url\":\"https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcQqAqo_sD2jJU0PuPF97ALJvGYraElJ2mN1bgYSO4PCtQFLBQpPJMqlaB9Ng3d_LTziA2q_R6S-S8BGUEuh5cEIlTk0OQeFpw&usqp=CAY\",\"color_recommendations_search_engine_query_result2_buy_now_url\":\"https://www.google.com/url?q=http://www.myntra.com/Shirts/Mast%2B%2526%2BHarbour/Mast--Harbour-Beige-Classic-Slim-Fit-Casual-Cotton-Linen-Shirt/22677784/buy&opi=95576897&sa=U&ved=0ahUKEwj7ycyUrMqKAxXCXmwGHepSOlEQ1ykIFQ&usg=AOvVaw0RU4iyIK_fxg78-J9d85ZJ\",\"color_recommendations_search_engine_query_result3_title\":\"trueBrowns Men Solid Cotton Shirt (44) by Myntra\",\"color_recommendations_search_engine_query_result3_price\":\"₹1,499.00\",\"color_recommendations_search_engine_query_result3_url\":\"https://www.google.com/shopping/product/9818686436438459259?hl=en&q=classic+tone+shirts+for+men&prds=eto:2025187272694127552_0,pid:16864886671503871900&sa=X&ved=0ahUKEwjapPqSrMqKAxVWdfUHHbOeLZIQ8gIIuAooAA\",\"color_recommendations_search_engine_query_result3_image_url\":\"https://encrypted-tbn0.gstatic.com/shopping?q=tbn:ANd9GcQNiiYOfRo7xuimdtSNsZneS0WqM0pBSV4ikxvJGTUwvYfjSrAw-WvxPK4HuuogpRTtfaqaOYV5sY61mJ8sNeKzyYEhB6s-yQ&usqp=CAY\",\"color_recommendations_search_engine_query_result3_buy_now_url\":\"https://www.google.com/url?q=https://www.truebrowns.com/products/truebrowns-mens-purple-cotton-shirt%3Fvariant%3D45770522099968%26country%3DIN%26currency%3DINR%26utm_medium%3Dproduct_sync%26utm_source%3Dgoogle%26utm_content%3Dsag_organic%26utm_campaign%3Dsag_organic%26srsltid%3DAfmBOophqHWi4YRi92bN8RjU5YYxTUmyqmZ_fOIj-NnWu5cJPqkQ6OgGV4c%26com_cvv%3Dd30042528f072ba8a22b19c81250437cd47a2f30330f0ed03551c4efdaf3409e&opi=95576897&sa=U&ved=0ahUKEwjzhoaVrMqKAxUiRmwGHeCHB8sQ1ykIFw&usg=AOvVaw0SyFj8W2T7XL111wvFfGOT\",\"color_recommendations_search_engine_query_result4_title\":\"The Indian Garage Co. Men Striped Casual Green Shirt\",\"color_recommendations_search_engine_query_result4_price\":\"₹544.00\",\"color_recommendations_search_engine_query_result4_url\":\"https://www.google.com/shopping/product/9297409144555296087?hl=en&q=classic+tone+shirts+for+men&prds=eto:17822554198368166938_0,pid:8697096145242182124,rsk:PC_1837918737675362908&sa=X&ved=0ahUKEwjapPqSrMqKAxVWdfUHHbOeLZIQ8gIIyQooAA\",\"color_recommendations_search_engine_query_result4_image_url\":\"https://encrypted-tbn1.gstatic.com/shopping?q=tbn:ANd9GcQyKXUOvP5T1wkKJ-qaN2sZQoXiipK6n24Hj2yOVq60ARPWkwDtepCA16GdGsgJIZJCCKG5RMDfNX-y2eEET1UUwd54dXfS&usqp=CAY\",\"color_recommendations_search_engine_query_result4_buy_now_url\":\"https://www.google.com/url?q=https://www.ajio.com/the-indian-garage-co-men-striped-slim-fit-shirt-with-patch-pocket/p/460453608_olive%3Fsrsltid%3DAfmBOooBc7mTAjOKeOxEVsGITmiKt1e5pablp8AcfWI246DzU-IWaMpKfDU%23gmf&opi=95576897&sa=U&ved=0ahUKEwj_xLqVrMqKAxV6RmcHHdiULAAQ1ykIGQ&usg=AOvVaw2_2TcqvCV9onp3IbKetgwM\",\"color_recommendations_search_engine_query_result5_title\":\"Highlander Men Solid Casual Maroon Shirt\",\"color_recommendations_search_engine_query_result5_price\":\"₹679.00\",\"color_recommendations_search_engine_query_result5_url\":\"https://www.google.com/shopping/product/5883824593974501422?hl=en&q=classic+tone+shirts+for+men&prds=eto:2264648949438618266_0,pid:10583175608471014679,rsk:PC_7051784970224709959&sa=X&ved=0ahUKEwjapPqSrMqKAxVWdfUHHbOeLZIQ8gIIqQooAA\",\"color_recommendations_search_engine_query_result5_image_url\":\"https://encrypted-tbn2.gstatic.com/shopping?q=tbn:ANd9GcSZ9o38Zi1bxQTaaf-tWyj8mZ8RjMSKBBQKD4PXpNiug8F49qSeGldQAc0i-exjmOtA1_8_YMGodtYQWihIkatczdndvkJ0&usqp=CAY\",\"color_recommendations_search_engine_query_result5_buy_now_url\":\"https://www.google.com/url?q=http://www.flipkart.com/highlander-men-solid-casual-maroon-shirt/p/itm1bb7675611bb5%3Fpid%3DSHTGG9TMEMMRY3UZ%26lid%3DLSTSHTGG9TMEMMRY3UZ7RECSR%26marketplace%3DFLIPKART%26cmpid%3Dcontent_shirt_8965229628_gmc&opi=95576897&sa=U&ved=0ahUKEwjFiLKWrMqKAxUnTmwGHbWOHtwQ1ykIFQ&usg=AOvVaw0Q1oF7vWxxI0Pa3FdSawyA\"}";
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
                        imgcard1T.Image = Image.FromStream(stream);
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

            imgcard1T.Load("https://encrypted-tbn3.gstatic.com/shopping?q=tbn:ANd9GcTeSqsElF4HGb8InLOmOmAh7G9Ga3szXvObStMpfrb1RXBG5SDEYky0NTb43jd2yyfpVuJfY-O-Mav6rpJCfbEPWbII3-ubUBIUxB515BMH");
        }

        private void HideMeasurements() => panel_mhidden.Visible = false;
        private void ShowMeasurements() => panel_mhidden.Visible = panel_mhidden.Visible == false ? true : false;

        private void HideProdRecom() => panel_T.Visible = panel_B.Visible = panel_S.Visible = panel_C.Visible = false;

        private void ShowProdRecom()
        {
            panel_T.Visible = panel_T.Visible == false ? true : false;
            panel_B.Visible = panel_B.Visible == false ? true : false;
            panel_S.Visible = panel_S.Visible == false ? true : false;
            panel_C.Visible = panel_C.Visible == false ? true : false;
        }

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
                            //MessageBox.Show(formattedOutput, "Measurements", MessageBoxButtons.OK, MessageBoxIcon.Information);

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









        private void label_prodrecom_Click(object sender, EventArgs e)
        {
            ShowProdRecom();
        }


        private  async void CallCrawlerApi()
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

                byte[] responseBytes = await response.Content.ReadAsByteArrayAsync();

                // Define the file path where the raw data will be saved
                string filePath = @"D:\img_down\image_data.json";

                // Write the raw response bytes to the file
                File.WriteAllBytes(filePath, responseBytes);
                string jsonResponse = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(jsonResponse);
                Console.WriteLine(jsonResponse);

                //MessageBox.Show(jsonResponse, "JsonResponse", MessageBoxButtons.OK, MessageBoxIcon.Information);

                UserSession.crawlerApiResponse = jsonResponse;

                CallPythonScript();

            }
        }

        private void CallPythonScript()
        {
            // Set the Python executable path and script path
            // Path to your Python script

            try
            {
                // Configure process to hide the command prompt window
                ProcessStartInfo processInfo = new ProcessStartInfo
                {
                    FileName = UserSession.pythonPath,
                    Arguments = UserSession.scriptPath,
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
                    DisplayApiResponse();

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
        private  void DisplayApiResponse()
        {


            try
            {
                var json = JObject.Parse(UserSession.crawlerApiResponse);

                // Extract the Top wear search engine queries
                imgcard1T.Load(@"D:\img_down\outputs\top_wear_search_engine_query_result1_image.jpg");
                string title1T = json["top_wear_search_engine_query_result1_title"]?.ToString();
                string price1T = json["top_wear_search_engine_query_result1_price"]?.ToString();
                string buyNow1T = json["top_wear_search_engine_query_result1_buy_now_url"]?.ToString();

                imgcard2T.Load(@"D:\img_down\outputs\top_wear_search_engine_query_result2_image.jpg");
                string title2T = json["top_wear_search_engine_query_result2_title"]?.ToString();
                string price2T = json["top_wear_search_engine_query_result2_price"]?.ToString();
                string buyNow2T = json["top_wear_search_engine_query_result2_buy_now_url"]?.ToString();

                imgcard3T.Load(@"D:\img_down\outputs\top_wear_search_engine_query_result3_image.jpg");
                string title3T = json["top_wear_search_engine_query_result3_title"]?.ToString();
                string price3T = json["top_wear_search_engine_query_result3_price"]?.ToString();
                string buyNow3T = json["top_wear_search_engine_query_result3_buy_now_url"]?.ToString();

                imgcard4T.Load(@"D:\img_down\outputs\top_wear_search_engine_query_result4_image.jpg");
                string title4T = json["top_wear_search_engine_query_result4_title"]?.ToString();
                string price4T = json["top_wear_search_engine_query_result4_price"]?.ToString();
                string buyNow4T = json["top_wear_search_engine_query_result4_buy_now_url"]?.ToString();

                imgcard5T.Load(@"D:\img_down\outputs\top_wear_search_engine_query_result5_image.jpg");
                string title5T = json["top_wear_search_engine_query_result5_title"]?.ToString();
                string price5T = json["top_wear_search_engine_query_result5_price"]?.ToString();
                string buyNow5T = json["top_wear_search_engine_query_result5_buy_now_url"]?.ToString();


                btnTitle1T.Text = title1T;
                btnPrice1T.Text = price1T;
                btnBuy1T.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow1T) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle2T.Text = title2T;
                btnPrice2T.Text = price2T;
                btnBuy2T.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow2T) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle3T.Text = title3T;
                btnPrice3T.Text = price3T;
                btnBuy3T.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow3T) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle4T.Text = title4T;
                btnPrice4T.Text = price4T;
                btnBuy4T.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow4T) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle5T.Text = title5T;
                btnPrice5T.Text = price5T;
                btnBuy5T.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow5T) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };


                // Extract the Bottom wear  search engine queries
                imgcard1B.Load(@"D:\img_down\outputs\bottom_wear_search_engine_query_result1_image.jpg");
                string title1B = json["bottom_wear_search_engine_query_result1_title"]?.ToString();
                string price1B = json["bottom_wear_search_engine_query_result1_price"]?.ToString();
                string buyNow1B = json["bottom_wear_search_engine_query_result1_buy_now_url"]?.ToString();

                imgcard2B.Load(@"D:\img_down\outputs\bottom_wear_search_engine_query_result2_image.jpg");
                string title2B = json["bottom_wear_search_engine_query_result2_title"]?.ToString();
                string price2B = json["bottom_wear_search_engine_query_result2_price"]?.ToString();
                string buyNow2B = json["bottom_wear_search_engine_query_result2_buy_now_url"]?.ToString();

                imgcard3B.Load(@"D:\img_down\outputs\bottom_wear_search_engine_query_result3_image.jpg");
                string title3B = json["bottom_wear_search_engine_query_result3_title"]?.ToString();
                string price3B = json["bottom_wear_search_engine_query_result3_price"]?.ToString();
                string buyNow3B = json["bottom_wear_search_engine_query_result3_buy_now_url"]?.ToString();

                imgcard4B.Load(@"D:\img_down\outputs\bottom_wear_search_engine_query_result4_image.jpg");
                string title4B = json["bottom_wear_search_engine_query_result4_title"]?.ToString();
                string price4B = json["bottom_wear_search_engine_query_result4_price"]?.ToString();
                string buyNow4B = json["bottom_wear_search_engine_query_result4_buy_now_url"]?.ToString();

                imgcard5B.Load(@"D:\img_down\outputs\bottom_wear_search_engine_query_result5_image.jpg");
                string title5B = json["bottom_wear_search_engine_query_result5_title"]?.ToString();
                string price5B = json["bottom_wear_search_engine_query_result5_price"]?.ToString();
                string buyNow5B = json["bottom_wear_search_engine_query_result5_buy_now_url"]?.ToString();


                btnTitle1B.Text = title1B;
                btnPrice1B.Text = price1B;
                btnBuy1B.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow1B) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle2B.Text = title2B;
                btnPrice2B.Text = price2B;
                btnBuy2B.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow2B) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle3B.Text = title3B;
                btnPrice3B.Text = price3B;
                btnBuy3B.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow3B) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle4B.Text = title4B;
                btnPrice4B.Text = price4B;
                btnBuy4B.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow4B) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle5B.Text = title5B;
                btnPrice5B.Text = price5B;
                btnBuy5B.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow5B) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };


                // Extract the Shoes wear  search engine queries
                imgcard1S.Load(@"D:\img_down\outputs\shoes_search_engine_query_result1_image.jpg");
                string title1S = json["shoes_search_engine_query_result1_title"]?.ToString();
                string price1S = json["shoes_search_engine_query_result1_price"]?.ToString();
                string buyNow1S = json["shoes_search_engine_query_result1_buy_now_url"]?.ToString();

                imgcard2S.Load(@"D:\img_down\outputs\shoes_search_engine_query_result2_image.jpg");
                string title2S = json["shoes_search_engine_query_result2_title"]?.ToString();
                string price2S = json["shoes_search_engine_query_result2_price"]?.ToString();
                string buyNow2S = json["shoes_search_engine_query_result2_buy_now_url"]?.ToString();

                imgcard3S.Load(@"D:\img_down\outputs\shoes_search_engine_query_result3_image.jpg");
                string title3S = json["shoes_search_engine_query_result3_title"]?.ToString();
                string price3S = json["shoes_search_engine_query_result3_price"]?.ToString();
                string buyNow3S = json["shoes_search_engine_query_result3_buy_now_url"]?.ToString();

                imgcard4S.Load(@"D:\img_down\outputs\shoes_search_engine_query_result4_image.jpg");
                string title4S = json["shoes_search_engine_query_result4_title"]?.ToString();
                string price4S = json["shoes_search_engine_query_result4_price"]?.ToString();
                string buyNow4S = json["shoes_search_engine_query_result4_buy_now_url"]?.ToString();

                imgcard5S.Load(@"D:\img_down\outputs\shoes_search_engine_query_result5_image.jpg");
                string title5S = json["shoes_search_engine_query_result5_title"]?.ToString();
                string price5S = json["shoes_search_engine_query_result5_price"]?.ToString();
                string buyNow5S = json["shoes_search_engine_query_result5_buy_now_url"]?.ToString();



                btnTitle1S.Text = title1S;
                btnPrice1S.Text = price1S;
                btnBuy1S.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow1S) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle2S.Text = title2S;
                btnPrice2S.Text = price2S;
                btnBuy2S.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow2S) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle3S.Text = title3S;
                btnPrice3S.Text = price3S;
                btnBuy3S.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow3S) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle4S.Text = title4S;
                btnPrice4S.Text = price4S;
                btnBuy4S.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow4S) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle5S.Text = title5S;
                btnPrice5S.Text = price5S;
                btnBuy5S.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow5S) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };


                // Extract the Colour wear  search engine queries
                imgcard1C.Load(@"D:\img_down\outputs\color_recommendations_search_engine_query_result1_image.jpg");
                string title1C = json["color_recommendations_search_engine_query_result1_title"]?.ToString();
                string price1C = json["color_recommendations_search_engine_query_result1_price"]?.ToString();
                string buyNow1C = json["color_recommendations_search_engine_query_result1_buy_now_url"]?.ToString();

                imgcard2C.Load(@"D:\img_down\outputs\color_recommendations_search_engine_query_result2_image.jpg");
                string title2C = json["color_recommendations_search_engine_query_result2_title"]?.ToString();
                string price2C = json["color_recommendations_search_engine_query_result2_price"]?.ToString();
                string buyNow2C = json["color_recommendations_search_engine_query_result2_buy_now_url"]?.ToString();

                imgcard3C.Load(@"D:\img_down\outputs\color_recommendations_search_engine_query_result3_image.jpg");
                string title3C = json["color_recommendations_search_engine_query_result3_title"]?.ToString();
                string price3C = json["color_recommendations_search_engine_query_result3_price"]?.ToString();
                string buyNow3C = json["color_recommendations_search_engine_query_result3_buy_now_url"]?.ToString();

                imgcard4C.Load(@"D:\img_down\outputs\color_recommendations_search_engine_query_result4_image.jpg");
                string title4C = json["color_recommendations_search_engine_query_result4_title"]?.ToString();
                string price4C = json["color_recommendations_search_engine_query_result4_price"]?.ToString();
                string buyNow4C = json["color_recommendations_search_engine_query_result4_buy_now_url"]?.ToString();

                imgcard5C.Load(@"D:\img_down\outputs\color_recommendations_search_engine_query_result5_image.jpg");
                string title5C = json["color_recommendations_search_engine_query_result5_title"]?.ToString();
                string price5C = json["color_recommendations_search_engine_query_result5_price"]?.ToString();
                string buyNow5C = json["color_recommendations_search_engine_query_result5_buy_now_url"]?.ToString();


                btnTitle1C.Text = title1C;
                btnPrice1C.Text = price1C;
                btnBuy1C.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow1C) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle2C.Text = title2C;
                btnPrice2C.Text = price2C;
                btnBuy2C.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow2C) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle3C.Text = title3C;
                btnPrice3C.Text = price3C;
                btnBuy3C.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow3C) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle4C.Text = title4C;
                btnPrice4C.Text = price4C;
                btnBuy4C.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow4C) { UseShellExecute = true });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to open the URL: " + ex.Message);
                    }
                };

                btnTitle5C.Text = title5C;
                btnPrice5C.Text = price5C;
                btnBuy5C.Click += (sender, e) =>
                {
                    try
                    {
                        Process.Start(new ProcessStartInfo(buyNow5C) { UseShellExecute = true });
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
            CallCrawlerApi();

            //CallPythonScript();

            //DisplayApiResponse();
        }

        private void btnShowRecm_Click(object sender, EventArgs e)
        {
            CallRSEQApi();
        }

        private void label_showm_Click(object sender, EventArgs e)
        {
            FetchMeasurements();
            ShowMeasurements();
        }

        
    }
}
