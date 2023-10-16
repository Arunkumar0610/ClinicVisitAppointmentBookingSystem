Ö
ìC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\ScheduleMicroservice\BusinessLogicLayer\Services\IServices\IScheduleService.cs
	namespace		 	
BusinessLogicLayer		
 
.		 
Services		 %
.		% &
	IServices		& /
{

 
public 

	interface 
IScheduleService %
{ 
public 
Task 
< 
List 
< 
ClinicServicesDto *
>* +
>+ ,
GetAll- 3
(3 4
)4 5
;5 6
public 
Task 
< 
List 
< 
ClinicServicesDto *
>* +
>+ ,"
GetAllClinicsByService- C
(C D
stringE K
serviceL S
)S T
;T U
public 
Task 
< 
ClinicServicesDto %
>% &
GetClinicById' 4
(4 5
string5 ;
ClinicId< D
)D E
;E F
public 
Task 
< 
ClinicServicesDto %
>% &
AddServices' 2
(2 3#
ClinicServicesCreateDto3 J
clinicservicesK Y
)Y Z
;Z [
public 
Task 
< 
List 
< "
ScheduleAppointmentDto /
>/ 0
>0 1&
GetAllScheduleAppointments2 L
(L M
)M N
;N O
public 
Task 
< "
ScheduleAppointmentDto *
>* +"
AddScheduleAppointment, B
(B C(
ScheduleAppointmentCreateDtoC _
scheduleAppointment` s
)s t
;t u
public 
Task 
< "
ScheduleAppointmentDto *
>* +"
GetScheduleAppointment, B
(B C
stringC I
IdJ L
)L M
;M N
} 
} €w
àC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\ScheduleMicroservice\BusinessLogicLayer\Services\ScheduleService.cs
	namespace 	
BusinessLogicLayer
 
. 
Services %
{ 
public 

class 
ScheduleService  
:! "
IScheduleService# 3
{ 
private 
readonly 
IMongoCollection )
<) *
ClinicServices* 8
>8 9
_clinicServices: I
;I J
private 
readonly 
IMongoCollection )
<) *
ScheduleAppointment* =
>= > 
_scheduleAppointment? S
;S T
private 
readonly 
ILogger  
<  !
ScheduleService! 0
>0 1
logger2 8
;8 9
private 
readonly 
IMapper  
_mapper! (
;( )
public 
ScheduleService 
( 
IDataBaseSettings 0
settings1 9
,9 :
ILogger; B
<B C
ScheduleServiceC R
>R S
_loggerT [
,[ \
IMapper] d
mappere k
)k l
{ 	
var 
client 
= 
new 
MongoClient (
(( )
settings) 1
.1 2
ConnectionString2 B
)B C
;C D
var 
database 
= 
client !
.! "
GetDatabase" -
(- .
settings. 6
.6 7
DatabaseName7 C
)C D
;D E
_clinicServices 
= 
database &
.& '
GetCollection' 4
<4 5
ClinicServices5 C
>C D
(D E
settingsE M
.M N!
ClinicCollectionName1N c
)c d
;d e 
_scheduleAppointment  
=! "
database# +
.+ ,
GetCollection, 9
<9 :
ScheduleAppointment: M
>M N
(N O
settingsO W
.W X!
ClinicCollectionName2X m
)m n
;n o
logger 
= 
_logger 
; 
_mapper 
= 
mapper 
; 
} 	
public   
async   
Task   
<   
List   
<   
ClinicServicesDto   0
>  0 1
>  1 2
GetAll  3 9
(  9 :
)  : ;
{!! 	
try"" 
{## 
logger$$ 
.$$ 
LogInformation$$ %
($$% &
$str$$& 5
)$$5 6
;$$6 7
var%% 

cliniclist%% 
=%%  
await%%! &
_clinicServices%%' 6
.%%6 7
Find%%7 ;
(%%; <
s%%< =
=>%%> @
true%%A E
)%%E F
.%%F G
ToListAsync%%G R
(%%R S
)%%S T
;%%T U
return&& 
_mapper&& 
.&& 
Map&& "
<&&" #
List&&# '
<&&' (
ClinicServicesDto&&( 9
>&&9 :
>&&: ;
(&&; <

cliniclist&&< F
)&&F G
;&&G H
}'' 
catch(( 
((( 
	Exception(( 
ex(( 
)((  
{)) 
logger** 
.** 
LogError** 
(**  
ex**  "
,**" #
$"**$ &
$str**& W
"**W X
)**X Y
;**Y Z
throw++ 
;++ 
},, 
}-- 	
public.. 
async.. 
Task.. 
<.. 
ClinicServicesDto.. +
>..+ ,
GetClinicById..- :
(..: ;
string..; A
ClinicId..B J
)..J K
{// 	
try00 
{11 
logger22 
.22 
LogInformation22 %
(22% &
$str22& 5
)225 6
;226 7
var33 
appointment33 
=33  !
await33" '
_clinicServices33( 7
.337 8
Find338 <
(33< =
s33= >
=>33? A
s33B C
.33C D
Id33D F
==33G I
ClinicId33J R
)33R S
.33S T
FirstOrDefaultAsync33T g
(33g h
)33h i
;33i j
if44 
(44 
appointment44 
==44  "
null44# '
)44' (
{55 
return66 
new66 
ClinicServicesDto66 0
(660 1
)661 2
;662 3
}77 
return88 
_mapper88 
.88 
Map88 "
<88" #
ClinicServicesDto88# 4
>884 5
(885 6
appointment886 A
)88A B
;88B C
}99 
catch:: 
(:: 
	Exception:: 
ex:: 
)::  
{;; 
logger<< 
.<< 
LogError<< 
(<<  
ex<<  "
,<<" #
$"<<$ &
$str<<& Y
"<<Y Z
)<<Z [
;<<[ \
throw== 
;== 
}>> 
}?? 	
public@@ 
async@@ 
Task@@ 
<@@ 
List@@ 
<@@ 
ClinicServicesDto@@ 0
>@@0 1
>@@1 2"
GetAllClinicsByService@@3 I
(@@I J
string@@J P
service@@Q X
)@@X Y
{AA 	
tryBB 
{CC 
loggerDD 
.DD 
LogInformationDD %
(DD% &
$strDD& 5
)DD5 6
;DD6 7
varEE 

cliniclistEE 
=EE  
awaitEE! &
_clinicServicesEE' 6
.EE6 7
FindEE7 ;
(EE; <
sEE< =
=>EE> @
sEEA B
.EEB C
ServicesEEC K
.EEK L
ContainsEEL T
(EET U
serviceEEU \
)EE\ ]
)EE] ^
.EE^ _
ToListAsyncEE_ j
(EEj k
)EEk l
;EEl m
ifFF 
(FF 

cliniclistFF 
.FF 
CountFF $
>FF% &
$numFF' (
)FF( )
{GG 
returnHH 
_mapperHH "
.HH" #
MapHH# &
<HH& '
ListHH' +
<HH+ ,
ClinicServicesDtoHH, =
>HH= >
>HH> ?
(HH? @

cliniclistHH@ J
)HHJ K
;HHK L
}II 
returnJJ 
newJJ 
ListJJ 
<JJ  
ClinicServicesDtoJJ  1
>JJ1 2
(JJ2 3
)JJ3 4
;JJ4 5
}KK 
catchLL 
(LL 
	ExceptionLL 
exLL 
)LL  
{MM 
loggerNN 
.NN 
LogErrorNN 
(NN  
exNN  "
,NN" #
$"NN$ &
$strNN& ^
"NN^ _
)NN_ `
;NN` a
throwOO 
;OO 
}PP 
}QQ 	
publicRR 
asyncRR 
TaskRR 
<RR 
ClinicServicesDtoRR +
>RR+ ,
AddServicesRR- 8
(RR8 9#
ClinicServicesCreateDtoRR9 P
clinicservicesRRQ _
)RR_ `
{SS 	
tryTT 
{UU 
loggerVV 
.VV 
LogInformationVV %
(VV% &
$strVV& 1
)VV1 2
;VV2 3
varWW 
countWW 
=WW 
awaitWW !
_clinicServicesWW" 1
.WW1 2
FindWW2 6
(WW6 7
sWW7 8
=>WW9 ;
sWW< =
.WW= >

ClinicNameWW> H
==WWI K
clinicservicesWWL Z
.WWZ [

ClinicNameWW[ e
)WWe f
.WWf g
CountDocumentsAsyncWWg z
(WWz {
)WW{ |
;WW| }
ifXX 
(XX 
countXX 
==XX 
$numXX 
)XX 
{YY 
ClinicServicesZZ "
itemZZ# '
=ZZ( )
newZZ* -
ClinicServicesZZ. <
(ZZ< =
)ZZ= >
{[[ 
Id\\ 
=\\ 
$str\\ 
,\\  

ClinicName]] "
=]]# $
clinicservices]]% 3
.]]3 4

ClinicName]]4 >
,]]> ?
ClinicAddress^^ %
=^^& '
clinicservices^^( 6
.^^6 7
ClinicAddress^^7 D
,^^D E
Services__  
=__! "
clinicservices__# 1
.__1 2
Services__2 :
}`` 
;`` 
awaitaa 
_clinicServicesaa )
.aa) *
InsertOneAsyncaa* 8
(aa8 9
itemaa9 =
)aa= >
;aa> ?
returnbb 
_mapperbb "
.bb" #
Mapbb# &
<bb& '
ClinicServicesDtobb' 8
>bb8 9
(bb9 :
itembb: >
)bb> ?
;bb? @
}cc 
returndd 
newdd 
ClinicServicesDtodd ,
(dd, -
)dd- .
;dd. /
}ee 
catchff 
(ff 
	Exceptionff 
exff 
)ff  
{gg 
loggerhh 
.hh 
LogErrorhh 
(hh  
exhh  "
,hh" #
$"hh$ &
$strhh& O
"hhO P
)hhP Q
;hhQ R
throwii 
;ii 
}jj 
}ll 	
publicmm 
asyncmm 
Taskmm 
<mm 
Listmm 
<mm "
ScheduleAppointmentDtomm 5
>mm5 6
>mm6 7&
GetAllScheduleAppointmentsmm8 R
(mmR S
)mmS T
{nn 	
tryoo 
{pp 
loggerqq 
.qq 
LogInformationqq %
(qq% &
$strqq& 5
)qq5 6
;qq6 7
varrr 
appointmentslistrr $
=rr% &
awaitrr' , 
_scheduleAppointmentrr- A
.rrA B
FindrrB F
(rrF G
srrG H
=>rrI K
truerrL P
)rrP Q
.rrQ R
ToListAsyncrrR ]
(rr] ^
)rr^ _
;rr_ `
returnss 
_mapperss 
.ss 
Mapss "
<ss" #
Listss# '
<ss' ("
ScheduleAppointmentDtoss( >
>ss> ?
>ss? @
(ss@ A
appointmentslistssA Q
)ssQ R
;ssR S
}tt 
catchuu 
(uu 
	Exceptionuu 
exuu 
)uu  
{vv 
loggerww 
.ww 
LogErrorww 
(ww  
exww  "
,ww" #
$"ww$ &
$strww& _
"ww_ `
)ww` a
;wwa b
throwxx 
;xx 
}yy 
}zz 	
public{{ 
async{{ 
Task{{ 
<{{ "
ScheduleAppointmentDto{{ 0
>{{0 1"
AddScheduleAppointment{{2 H
({{H I(
ScheduleAppointmentCreateDto{{I e
scheduleAppointment{{f y
){{y z
{|| 	
try}} 
{~~ 
logger 
. 
LogInformation %
(% &
$str& 5
)5 6
;6 7!
ScheduleAppointment
ÄÄ #
schedule
ÄÄ$ ,
=
ÄÄ- .
new
ÄÄ/ 2!
ScheduleAppointment
ÄÄ3 F
(
ÄÄF G
)
ÄÄG H
{
ÅÅ 
Id
ÇÇ 
=
ÇÇ 
$str
ÇÇ 
,
ÇÇ 
PatientuserName
ÉÉ #
=
ÉÉ$ %!
scheduleAppointment
ÉÉ& 9
.
ÉÉ9 :
PatientuserName
ÉÉ: I
,
ÉÉI J

ClinicName
ÑÑ 
=
ÑÑ  !
scheduleAppointment
ÑÑ! 4
.
ÑÑ4 5

ClinicName
ÑÑ5 ?
,
ÑÑ? @
ClinicAddress
ÖÖ !
=
ÖÖ" #!
scheduleAppointment
ÖÖ$ 7
.
ÖÖ7 8
ClinicAddress
ÖÖ8 E
,
ÖÖE F
Service
ÜÜ 
=
ÜÜ !
scheduleAppointment
ÜÜ 1
.
ÜÜ1 2
Service
ÜÜ2 9
,
ÜÜ9 :
DateTimeOfVisit
áá #
=
áá$ %!
scheduleAppointment
áá& 9
.
áá9 :
DateTimeOfVisit
áá: I
}
àà 
;
àà 
if
ââ 
(
ââ !
scheduleAppointment
ââ '
.
ââ' (
DateTimeOfVisit
ââ( 7
>=
ââ8 :
DateTime
ââ; C
.
ââC D
Now
ââD G
)
ââG H
{
ää 
await
ãã "
_scheduleAppointment
ãã .
.
ãã. /
InsertOneAsync
ãã/ =
(
ãã= >
schedule
ãã> F
)
ããF G
;
ããG H
return
åå 
_mapper
åå "
.
åå" #
Map
åå# &
<
åå& '$
ScheduleAppointmentDto
åå' =
>
åå= >
(
åå> ?
schedule
åå? G
)
ååG H
;
ååH I
}
çç 
return
éé 
new
éé $
ScheduleAppointmentDto
éé 1
(
éé1 2
)
éé2 3
;
éé3 4
}
èè 
catch
êê 
(
êê 
	Exception
êê 
ex
êê 
)
êê  
{
ëë 
logger
íí 
.
íí 
LogError
íí 
(
íí  
ex
íí  "
,
íí" #
$"
íí$ &
$str
íí& R
"
ííR S
)
ííS T
;
ííT U
throw
ìì 
;
ìì 
}
îî 
}
ïï 	
public
ññ 
async
ññ 
Task
ññ 
<
ññ $
ScheduleAppointmentDto
ññ 0
>
ññ0 1$
GetScheduleAppointment
ññ2 H
(
ññH I
string
ññI O
Id
ññP R
)
ññR S
{
óó 	
try
òò 
{
ôô 
logger
öö 
.
öö 
LogInformation
öö %
(
öö% &
$str
öö& 5
)
öö5 6
;
öö6 7
var
õõ 
appointment
õõ 
=
õõ  !
await
õõ" '"
_scheduleAppointment
õõ( <
.
õõ< =
Find
õõ= A
(
õõA B
s
õõB C
=>
õõD F
s
õõG H
.
õõH I
Id
õõI K
==
õõL N
Id
õõO Q
)
õõQ R
.
õõR S!
FirstOrDefaultAsync
õõS f
(
õõf g
)
õõg h
;
õõh i
if
úú 
(
úú 
appointment
úú 
==
úú  "
null
úú# '
)
úú' (
{
ùù 
return
ûû 
new
ûû $
ScheduleAppointmentDto
ûû 5
(
ûû5 6
)
ûû6 7
;
ûû7 8
}
üü 
return
†† 
_mapper
†† 
.
†† 
Map
†† "
<
††" #$
ScheduleAppointmentDto
††# 9
>
††9 :
(
††: ;
appointment
††; F
)
††F G
;
††G H
}
°° 
catch
¢¢ 
(
¢¢ 
	Exception
¢¢ 
ex
¢¢ 
)
¢¢  
{
££ 
logger
§§ 
.
§§ 
LogError
§§ 
(
§§  
ex
§§  "
,
§§" #
$"
§§$ &
$str
§§& _
"
§§_ `
)
§§` a
;
§§a b
throw
•• 
;
•• 
}
¶¶ 
}
®® 	
}
©© 
}™™ 