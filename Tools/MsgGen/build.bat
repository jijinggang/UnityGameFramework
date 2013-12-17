echo on
SET IN = "%1"
SET OUT= "%2"

echo import "options.proto"; > protobuf\msg.proto
@more +3 "%1" >> protobuf/msg.proto
rem @more +3 %IN2% >> protobuf\msg.proto



cd protobuf
protoc --descriptor_set_out=options.protobin --include_imports options.proto
protogen options.protobin


protoc --descriptor_set_out=msg.protobin --include_imports msg.proto
CSharpProtoGen msg.protobin ./
protogen msg.protobin

del *.protobin
del msg.proto
del DescriptorProtoFile.cs
cd ..

mkdir "%2"
copy protobuf\*.cs "%2"
del protobuf\*.cs

