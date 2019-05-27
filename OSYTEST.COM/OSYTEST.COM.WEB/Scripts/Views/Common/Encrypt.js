/* 
 * *********************************************************************************************** //
 * MODIFIED DATE    : 2016-08-30( CREATED - 암호화 )
 * MODIFIER         : DAN LEE
 * DESCRIPTION      : Encryption Functions
 *                    /Scripts/Encrypt 하부 .js 파일들 필요
 * *********************************************************************************************** //
*/


/* INITIALIZE - Objective Functions */
var _Encrypt =
{
    RSA_PUBLIC_KEY: '<RSAKeyValue><Modulus>ike7ohVMQ05z09Y56cS7FwSlrBjyd02hFIAkZKElSm9e/wNeUc8cRQv/NUK5Ot1DrBQOJEojcGuqOJ4Ic41swKYYkGllAtTonhPCVx/AR2zZV0nXz44QIO3QEjODXibTFA+QJsA3FwJuAi2SzF6P3l/IwCgGl6NzdOx519oM3oc=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>'
    ,

    /* Functions for Encryption or Decryption */
    GetNewRsaProvider: function (dwKeySize) {

        // Create a new instance of RSACryptoServiceProvider.
        if (!dwKeySize)
            dwKeySize = 1024;

        return new System.Security.Cryptography.RSACryptoServiceProvider(dwKeySize);
    }
    ,
    GetRsaKey: function (includePrivateParameters) {

        var xmlParams = this.RSA_PUBLIC_KEY;

        // RSA Keys
        var rsa = this.GetNewRsaProvider();

        // Import parameters from xml.
        rsa.FromXmlString(xmlParams);

        // Export RSA key to RSAParameters and include:
        //    false - Only public key required for encryption.
        //    true  - Private key required for decryption.
        return rsa.ExportParameters(includePrivateParameters);
    }
    ,
    GetRsaKeyWithPrivateKey: function (includePrivateParameters, privateKey) {

        var xmlParams = privateKey;

        // RSA Keys
        var rsa = this.GetNewRsaProvider();

        // Import parameters from xml.
        rsa.FromXmlString(xmlParams);

        // Export RSA key to RSAParameters and include:
        //    false - Only public key required for encryption.
        //    true  - Private key required for decryption.
        return rsa.ExportParameters(includePrivateParameters);
    }
    ,
    // *********************************************************************************************** //
    // CODE SNIPPET     : _Encrypt.RsaEncrypt('Hello. Interpark');
    // *********************************************************************************************** //
    RsaEncrypt: function ( plainText) {
        /// <summary>평문을 RSA 알고리즘으로 암호화하고 이를 반환합니다.</summary>
        /// <param name="plainText" type="String">암호화 할 문자열</param>
        /// <returns type="string">암호화된 Text</returns>


        // Return Value
        var returnResult = '';

        var decryptedBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        var doOaepPadding = true;

        // Encrypt
        var rsa = this.GetNewRsaProvider();

        // Import the RSA Key information.
        rsa.ImportParameters(this.GetRsaKey(false));

        // Encrypt the passed byte array and specify OAEP padding.
        var encryptedBytes = rsa.Encrypt(decryptedBytes, doOaepPadding);
        var encryptedString = System.Convert.ToBase64String(encryptedBytes)

        returnResult = encryptedString;

        return returnResult;
    }
    ,
    RsaDecrypt: function (cipheredText, privateKey) {
        /// <summary>암호문을 복호화하고 이를 반환합니다.</summary>
        /// <param name="cipheredText" type="String">복호화 할 문자열</param>
        /// <param name="privateKey" type="String">RSA 개인키</param>
        /// <returns type="string">복호화된 Text</returns>


        // Return Value
        var returnResult = '';

        var encryptedBytes = System.Convert.FromBase64String(cipheredText);
        var doOaepPadding = true;

        // Decrypt
        var rsa = _Encrypt.GetNewRsaProvider();

        // Import the RSA Key information.
        rsa.ImportParameters(_Encrypt.GetRsaKeyWithPrivateKey(true, privateKey));

        // Decrypt the passed byte array and specify OAEP padding.
        var decryptedBytes = rsa.Decrypt(encryptedBytes, doOaepPadding);

        // Display the decrypted data.
        var decryptedString = System.Text.Encoding.UTF8.GetString(decryptedBytes);

        returnResult = decryptedString;

        return returnResult;
    }

};


