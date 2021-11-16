import subprocess
import os

run_dotnet_commands = "dotnet watch run t1/SEP3BlazorT1Client/SEP3BlazorT1Client/; dotnet run t2/SEP3T2API/SEP3T2API/SEP3T2GraphQL;";

ret = subprocess.run(run_dotnet_commands, stdout=subprocess.PIPE,  shell=True); 

run_springboot_command = "mvn spring-boot:run "; 

os.chdir("t3/viabnb.tier3.dataserver.soapws/");

ret2 = subprocess.run(run_springboot_command, stdout=subprocess.PIPE, shell=True); 


print(ret.stdout.decode); 
print (ret2.stdout.decode);