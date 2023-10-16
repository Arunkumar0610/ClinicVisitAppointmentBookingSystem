³^
‘C:\Users\921611\source\repos\Clinic Visit Appointment Booking System\ScheduleMicroservice\ScheduleMicroservice\Controllers\SchedulesController.cs
	namespace 	!
SchedulesMicroservice
 
.  
Controllers  +
{ 
[ 
Route 

(
 
$str 
) 
] 
[		 
ApiController		 
]		 
public

 

class

 
SchedulesController

 $
:

% &
ControllerBase

' 5
{ 
private 
readonly 
IScheduleService )
_scheduleService* :
;: ;
private 
readonly 
ILogger  
<  !
SchedulesController! 4
>4 5
logger6 <
;< =
public 
SchedulesController "
(" #
IScheduleService# 3
Repo4 8
,8 9
ILogger: A
<A B
SchedulesControllerB U
>U V
loggerW ]
)] ^
{ 	
_scheduleService 
= 
Repo #
;# $
this 
. 
logger 
= 
logger  
;  !
} 	
[ 	
HttpGet	 
( 
$str 
) 
]  
public 
async 
Task 
< 
ActionResult &
<& '
IEnumerable' 2
<2 3
ClinicServicesDto3 D
>D E
>E F
>F G
GetAllH N
(N O
)O P
{ 	
logger 
. 
LogInformation !
(! "
$str" ;
); <
;< =
var 
clinics 
= 
await 
_scheduleService  0
.0 1
GetAll1 7
(7 8
)8 9
;9 :
if 
( 
clinics 
. 
Count 
==  
$num! "
)" #
{ 
logger 
. 
LogError 
(  
$str  1
)1 2
;2 3
return 
NotFound 
(  
$str  2
)2 3
;3 4
} 
logger 
. 
LogInformation !
(! "
$str" F
)F G
;G H
return 
Ok 
( 
clinics 
) 
; 
}   	
[!! 	
HttpGet!!	 
(!! 
$str!! 
,!!  
Name!!! %
=!!& '
$str!!( 7
)!!7 8
]!!8 9
public"" 
async"" 
Task"" 
<"" 
ActionResult"" &
<""& '
ClinicServicesDto""' 8
>""8 9
>""9 :
GetClinicById""; H
(""H I
string""I O
Id""P R
)""R S
{## 	
logger%% 
.%% 
LogInformation%% !
(%%! "
$"%%" $
$str%%$ B
{%%B C
Id%%D F
}%%F G
"%%G H
)%%H I
;%%I J
var&& 
clinics&& 
=&& 
await&& 
_scheduleService&&  0
.&&0 1
GetClinicById&&1 >
(&&> ?
Id&&? A
)&&A B
;&&B C
if'' 
('' 
clinics'' 
.'' 

ClinicName'' "
==''# %
null''& *
)''* +
{(( 
logger)) 
.)) 
LogError)) 
())  
$str))  1
)))1 2
;))2 3
return** 
NotFound** 
(**  
$str**  1
)**1 2
;**2 3
}++ 
logger,, 
.,, 
LogInformation,, !
(,,! "
$",," $
$str,,$ @
{,,@ A
Id,,B D
},,E F
$str,,F S
",,S T
),,T U
;,,U V
return-- 
Ok-- 
(-- 
clinics-- 
)-- 
;-- 
}.. 	
[// 	
HttpGet//	 
(// 
$str// .
)//. /
]/// 0
public00 
async00 
Task00 
<00 
ActionResult00 &
<00& '
IEnumerable00' 2
<002 3
ClinicServicesDto003 D
>00D E
>00E F
>00F G
GetClinicsByService00H [
(00[ \
string00\ b
service00c j
)00j k
{11 	
logger22 
.22 
LogInformation22 !
(22! "
$str22" J
+22K L
service22M T
)22T U
;22U V
var33 
clinics33 
=33 
await33 
_scheduleService33  0
.330 1"
GetAllClinicsByService331 G
(33G H
service33H O
)33O P
;33P Q
if44 
(44 
clinics44 
.44 
Count44 
==44  
$num44! "
)44" #
{55 
logger66 
.66 
LogError66 
(66  
$str66  1
)661 2
;662 3
return77 
NotFound77 
(77  
$str77  2
)772 3
;773 4
}88 
logger99 
.99 
LogInformation99 !
(99! "
$"99" $
$str99$ I
{99I J
service99K R
}99S T
$str99T a
"99a b
)99b c
;99c d
return:: 
Ok:: 
(:: 
clinics:: 
):: 
;:: 
};; 	
[<< 	
HttpPost<<	 
(<< 
$str<< 
)<< 
]<<  
public== 
async== 
Task== 
<== 
ActionResult== &
<==& '
ClinicServicesDto==' 8
>==8 9
>==9 : 
AddClinicAndServices==; O
(==O P#
ClinicServicesCreateDto==P g
clinicServices==h v
)==v w
{>> 	
logger?? 
.?? 
LogInformation?? !
(??! "
$str??" 7
)??7 8
;??8 9
var@@ 
item@@ 
=@@ 
await@@ 
_scheduleService@@ -
.@@- .
AddServices@@. 9
(@@9 :
clinicServices@@: H
)@@H I
;@@I J
ifAA 
(AA 
itemAA 
.AA 

ClinicNameAA 
==AA !
nullAA! %
)AA% &
{BB 
loggerCC 
.CC 
LogErrorCC 
(CC  
$strCC  >
)CC> ?
;CC? @
returnDD 

BadRequestDD !
(DD! "
$strDD" @
)DD@ A
;DDA B
}EE 
loggerFF 
.FF 
LogInformationFF !
(FF! "
$strFF" D
)FFD E
;FFE F
returnGG 
CreatedAtActionGG "
(GG" #
nameofGG# )
(GG) *
GetClinicByIdGG* 7
)GG7 8
,GG8 9
newGG: =
{GG> ?
idGG@ B
=GGC D
itemGGE I
.GGI J
IdGGJ L
}GGM N
,GGN O
itemGGP T
)GGT U
;GGU V
}HH 	
[II 	
HttpPostII	 
(II 
$strII '
)II' (
]II( )
publicJJ 
asyncJJ 
TaskJJ 
<JJ 
ActionResultJJ &
<JJ& '"
ScheduleAppointmentDtoJJ' =
>JJ= >
>JJ> ?"
AddScheduleAppointmentJJ@ V
(JJV W(
ScheduleAppointmentCreateDtoJJW s
appointmentJJt 
)	JJ €
{KK 	
loggerLL 
.LL 
LogInformationLL !
(LL! "
$strLL" 5
)LL5 6
;LL6 7
varMM 
itemMM 
=MM 
awaitMM 
_scheduleServiceMM -
.MM- ."
AddScheduleAppointmentMM. D
(MMD E
appointmentMME P
)MMP Q
;MMQ R
ifNN 
(NN 
itemNN 
.NN 

ClinicNameNN 
==NN !
nullNN! %
)NN% &
{OO 
loggerPP 
.PP 
LogErrorPP 
(PP  
$strPP  ^
)PP^ _
;PP_ `
returnQQ 

BadRequestQQ !
(QQ! "
$strQQ" `
)QQ` a
;QQa b
}RR 
loggerSS 
.SS 
LogInformationSS !
(SS! "
$strSS" F
)SSF G
;SSG H
returnTT 
CreatedAtActionTT "
(TT" #
nameofTT# )
(TT) *
GetAppointmentByIdTT* <
)TT< =
,TT= >
newTT? B
{TTC D
idTTE G
=TTH I
itemTTJ N
.TTN O
IdTTO Q
}TTR S
,TTS T
itemTTU Y
)TTY Z
;TTZ [
}UU 	
[VV 	
HttpGetVV	 
(VV 
$strVV 
)VV 
]VV 
publicWW 
asyncWW 
TaskWW 
<WW 
ActionResultWW &
<WW& '
IEnumerableWW' 2
<WW2 3"
ScheduleAppointmentDtoWW3 I
>WWI J
>WWJ K
>WWK L
GetAllAppointmentsWWM _
(WW_ `
)WW` a
{XX 	
loggerYY 
.YY 
LogInformationYY !
(YY! "
$strYY" @
)YY@ A
;YYA B
varZZ 
appointmentsZZ 
=ZZ 
awaitZZ $
_scheduleServiceZZ% 5
.ZZ5 6&
GetAllScheduleAppointmentsZZ6 P
(ZZP Q
)ZZQ R
;ZZR S
if[[ 
([[ 
appointments[[ 
.[[ 
Count[[ "
==[[# %
$num[[& '
)[[' (
{\\ 
logger]] 
.]] 
LogError]] 
(]]  
$str]]  7
)]]7 8
;]]8 9
return^^ 
NotFound^^ 
(^^  
$str^^  7
)^^7 8
;^^8 9
}__ 
logger`` 
.`` 
LogInformation`` !
(``! "
$str``" K
)``K L
;``L M
returnaa 
Okaa 
(aa 
appointmentsaa "
)aa" #
;aa# $
}bb 	
[cc 	
HttpGetcc	 
(cc 
$strcc 
,cc 
Namecc 
=cc  !
$strcc! *
)cc* +
]cc+ ,
publicdd 
asyncdd 
Taskdd 
<dd 
ActionResultdd &
<dd& '"
ScheduleAppointmentDtodd' =
>dd= >
>dd> ?
GetAppointmentByIddd@ R
(ddR S
stringddS Y
IdddZ \
)dd\ ]
{ee 	
loggerff 
.ff 
LogInformationff !
(ff! "
$"ff" $
$strff$ G
{ffG H
IdffI K
}ffK L
"ffL M
)ffM N
;ffN O
vargg 
clinicsgg 
=gg 
awaitgg 
_scheduleServicegg  0
.gg0 1"
GetScheduleAppointmentgg1 G
(ggG H
IdggH J
)ggJ K
;ggK L
ifhh 
(hh 
clinicshh 
.hh 

ClinicNamehh "
==hh" $
nullhh$ (
)hh( )
{ii 
loggerjj 
.jj 
LogErrorjj 
(jj  
$strjj  6
)jj6 7
;jj7 8
returnkk 
NotFoundkk 
(kk  
$strkk  6
)kk6 7
;kk7 8
}ll 
loggermm 
.mm 
LogInformationmm !
(mm! "
$"mm" $
$strmm$ E
{mmE F
IdmmF H
}mmH I
$strmmI W
"mmW X
)mmX Y
;mmY Z
returnnn 
Oknn 
(nn 
clinicsnn 
)nn 
;nn 
}oo 	
}pp 
}qq ú
˜C:\Users\921611\source\repos\Clinic Visit Appointment Booking System\ScheduleMicroservice\ScheduleMicroservice\Middleware\ExceptionHandlingMiddleware.cs
	namespace		 	 
ScheduleMicroservice		
 
.		 

Middleware		 )
{

 
public 
class '
ExceptionHandlingMiddleware 0
{ 	
public 
RequestDelegate "
requestDelegate# 2
;2 3
public '
ExceptionHandlingMiddleware .
(. /
RequestDelegate/ >
requestDelegate? N
)N O
{ 
this 
. 
requestDelegate $
=% &
requestDelegate' 6
;6 7
} 
public 
async 
Task 
Invoke $
($ %
HttpContext% 0
context1 8
,8 9
ILogger: A
<A B'
ExceptionHandlingMiddlewareB ]
>] ^
logger_ e
)e f
{ 
try 
{ 
await 
requestDelegate )
() *
context* 1
)1 2
;2 3
} 
catch 
( 
	Exception  
ex! #
)# $
{ 
await 
HandleException )
() *
context* 1
,1 2
ex3 5
,5 6
logger7 =
)= >
;> ?
} 
} 
private 
static 
Task 
HandleException  /
(/ 0
HttpContext0 ;
context< C
,C D
	ExceptionE N
exO Q
,Q R
ILoggerS Z
<Z ['
ExceptionHandlingMiddleware[ v
>v w
loggerx ~
)~ 
{ 
logger 
. 
LogError 
(  
ex  "
." #
ToString# +
(+ ,
), -
)- .
;. /
var   
errorMessage    
=  ! "
JsonConvert  # .
.  . /
SerializeObject  / >
(  > ?
new  ? B
{  C D
Message  E L
=  M N
ex  O Q
.  Q R
Message  R Y
,  Y Z
Code  [ _
=  ` a
$str  b f
}  g h
)  h i
;  i j
context!! 
.!! 
Response!!  
.!!  !
ContentType!!! ,
=!!- .
$str!!/ A
;!!A B
context"" 
."" 
Response""  
.""  !

StatusCode""! +
="", -
("". /
int""/ 2
)""2 3
HttpStatusCode""3 A
.""A B
InternalServerError""B U
;""U V
return## 
context## 
.## 
Response## '
.##' (

WriteAsync##( 2
(##2 3
errorMessage##3 ?
)##? @
;##@ A
}$$ 
}(( 	
})) ÌB
yC:\Users\921611\source\repos\Clinic Visit Appointment Booking System\ScheduleMicroservice\ScheduleMicroservice\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
	Configure 
< 
DataBaseSettings +
>+ ,
(, -
builder 
. 
Configuration %
.% &

GetSection& 0
(0 1
nameof1 7
(7 8
DataBaseSettings8 H
)H I
)I J
)J K
;K L
builder 
. 
Services 
. 
AddSingleton 
< 
IDataBaseSettings /
>/ 0
(0 1
provider1 9
=>: <
provider 
. 	
GetRequiredService	 
< 
IOptions $
<$ %
DataBaseSettings% 5
>5 6
>6 7
(7 8
)8 9
.9 :
Value: ?
)? @
;@ A
builder 
. 
Services 
. 
	AddScoped 
< 
IScheduleService +
,+ ,
ScheduleService- <
>< =
(= >
)> ?
;? @
builder 
. 
Services 
. 
AddAutoMapper 
( 
typeof %
(% &
MappingConfig& 3
)3 4
)4 5
;5 6
var 
configuration 
= 
new  
ConfigurationBuilder ,
(, -
)- .
.. /
AddJsonFile/ :
(: ;
$str; M
)M N
.N O
BuildO T
(T U
)U V
;V W
Log 
. 
Logger 

= 
new 
LoggerConfiguration $
($ %
)% &
. 
ReadFrom 
. 
Configuration 
( 
configuration )
)) *
. 
CreateLogger 
( 
) 
; 
builder 
. 
Host 
. 

UseSerilog 
( 
) 
; 
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
var!! 
key!! 
=!! 	
builder!!
 
.!! 
Configuration!! 
.!!  
GetValue!!  (
<!!( )
string!!) /
>!!/ 0
(!!0 1
$str!!1 :
)!!: ;
;!!; <
builder"" 
."" 
Services"" 
."" 
AddAuthentication"" "
(""" #
x""# $
=>""% '
{## 
x$$ 
.$$ %
DefaultAuthenticateScheme$$ 
=$$  !
JwtBearerDefaults$$" 3
.$$3 4 
AuthenticationScheme$$4 H
;$$H I
x%% 
.%% "
DefaultChallengeScheme%% 
=%% 
JwtBearerDefaults%% 0
.%%0 1 
AuthenticationScheme%%1 E
;%%E F
}&& 
)&& 
.&& 
AddJwtBearer&& 
(&& 
x&& 
=>&& 
{'' 
x(( 
.((  
RequireHttpsMetadata(( 
=(( 
false(( "
;((" #
x)) 
.)) 
	SaveToken)) 
=)) 
true)) 
;)) 
x** 
.** %
TokenValidationParameters** 
=**  !
new**" %%
TokenValidationParameters**& ?
{++ $
ValidateIssuerSigningKey,,  
=,,! "
true,,# '
,,,' (
IssuerSigningKey-- 
=-- 
new--  
SymmetricSecurityKey-- 3
(--3 4
Encoding--4 <
.--< =
ASCII--= B
.--B C
GetBytes--C K
(--K L
key--L O
)--O P
)--P Q
,--Q R
ValidateIssuer.. 
=.. 
false.. 
,.. 
ValidateAudience// 
=// 
false//  
,//  !
ValidateLifetime00 
=00 
true00 
,00  
	ClockSkew11 
=11 
TimeSpan11 
.11 
Zero11 
}22 
;22 
}33 
)33 
;33 
builder55 
.55 
Services55 
.55 #
AddEndpointsApiExplorer55 (
(55( )
)55) *
;55* +
builder88 
.88 
Services88 
.88 
AddSwaggerGen88 
(88 
options88 &
=>88' )
{99 
options:: 
.:: !
AddSecurityDefinition:: !
(::! "
$str::" *
,::* +
new::, /!
OpenApiSecurityScheme::0 E
{;; 
Description<< 
=<< 
$str<< R
+<<S T
$str== V
+==W X
$str>> +
,>>+ ,
Name?? 
=?? 
$str?? 
,?? 
In@@ 

=@@ 
ParameterLocation@@ 
.@@ 
Header@@ %
,@@% &
SchemeAA 
=AA 
$strAA 
}CC 
)CC 
;CC 
optionsDD 
.DD "
AddSecurityRequirementDD "
(DD" #
newDD# &&
OpenApiSecurityRequirementDD' A
(DDA B
)DDB C
{EE 
{FF 	
newGG !
OpenApiSecuritySchemeGG %
{HH 
	ReferenceII 
=II 
newII 
OpenApiReferenceII .
{JJ 
TypeKK 
=KK 
ReferenceTypeKK &
.KK& '
SecuritySchemeKK' 5
,KK5 6
IdLL 
=LL 
$strLL 
}MM 
,MM 
SchemeNN 
=NN 
$strNN 
,NN  
NameOO 
=OO 
$strOO 
,OO 
InPP 
=PP 
ParameterLocationPP $
.PP$ %
HeaderPP% +
}QQ 
,QQ 
newRR 
ListRR 
<RR 
stringRR 
>RR 
(RR 
)RR 
}SS 	
}TT 
)TT 
;TT 
}UU 
)UU 
;UU 
varXX 
appXX 
=XX 	
builderXX
 
.XX 
BuildXX 
(XX 
)XX 
;XX 
appYY 
.YY 
UseMiddlewareYY 
(YY 
typeofYY 
(YY '
ExceptionHandlingMiddlewareYY 4
)YY4 5
)YY5 6
;YY6 7
if[[ 
([[ 
app[[ 
.[[ 
Environment[[ 
.[[ 
IsDevelopment[[ !
([[! "
)[[" #
)[[# $
{\\ 
app]] 
.]] 

UseSwagger]] 
(]] 
)]] 
;]] 
app^^ 
.^^ 
UseSwaggerUI^^ 
(^^ 
)^^ 
;^^ 
app__ 
.__ %
UseDeveloperExceptionPage__ !
(__! "
)__" #
;__# $
}`` 
appaa 
.aa 
UseCorsaa 
(aa 
xaa 
=>aa 
{bb 
xcc 
.cc 
WithOriginscc 
(cc 
$strcc )
)cc) *
.cc* +
AllowAnyHeadercc+ 9
(cc9 :
)cc: ;
.cc; <
AllowAnyMethodcc< J
(ccJ K
)ccK L
;ccL M
}dd 
)dd 
;dd 
appee 
.ee 
UseHttpsRedirectionee 
(ee 
)ee 
;ee 
appgg 
.gg $
UseSerilogRequestLogginggg 
(gg 
)gg 
;gg 
appii 
.ii 
UseAuthenticationii 
(ii 
)ii 
;ii 
appkk 
.kk 
UseAuthorizationkk 
(kk 
)kk 
;kk 
appmm 
.mm 
MapControllersmm 
(mm 
)mm 
;mm 
appoo 
.oo 
Runoo 
(oo 
)oo 	
;oo	 
