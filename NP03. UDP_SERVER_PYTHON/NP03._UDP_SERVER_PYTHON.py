import socket

localIP = '127.0.0.1'
localPort = 27001

bufferSize = 1024
msg = ''

UDPClientSocket = socket.socket(family=socket.AF_INET, type=socket.SOCK_DGRAM)
UDPClientSocket.bind((localIP, localPort))

print("UDP Client listening")

while True:
    bytesAddressPair = UDPClientSocket.recvfrom(bufferSize)
    msg = bytesAddressPair[0]
    address = bytesAddressPair[1]
    print(f"{address} - {msg}")
