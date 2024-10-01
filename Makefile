all:
	set export_pw=000a000a && \
	openssl genpkey -algorithm ED25519 -out ed25519_private.pem && \
	openssl req -x509 -new -nodes -key ed25519_private.pem -sha256 -days 1024 -out rootCA.pem -subj "/C=US/ST=California/L=Los Angeles/O=Developer Express Inc/OU=Client Services/CN=Signature" && \
	openssl req -new -key ed25519_private.pem -out pdfsigning.csr -subj "/C=US/ST=California/L=Los Angeles/O=Developer Express Inc/OU=Client Services/CN=PDF Signing" && \
	openssl x509 -req -in pdfsigning.csr -CA rootCA.pem -CAkey ed25519_private.pem -CAcreateserial -out pdfsigning.crt -days 500 -sha256 && \
	openssl pkcs12 -export -out pdfsigning.pfx -inkey ed25519_private.pem -in pdfsigning.crt -passout pass:000a000a
	# openssl pkcs12 -export -out pdfsigning.pfx -inkey ed25519_private.pem -in pdfsigning.crt -passout pass:$export_pw


