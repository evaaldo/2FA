<h1>Login - Autenticação JWT + 2FA Google Authenticator</h1>

<h4>✦ Resumo</h4>
<p>Uma tela de login criada para redirecionamento com base em consulta de usuário em banco de dados, geração de token JWT e autenticação do mesmo dentro do google authenticator via PIN.</p>

<h4>✦ Ferramentas</h4>
<ul>
    <li>HTML</li>
    <li>CSS</li>
    <li>Javascript</li>
	<li>.NET 6</li>
	<li>Dapper</li>
	<li>SQL</li>
</ul>

<h4>✦ Endpoints</h4>
<ul>
    <li>"/auth/generateQr/{email}" => GET - Gerar QR Code</li>
    <li>"auth/validateCode" => POST - Validar código PIN</li>
    <li>"auth/validateCode" => POST - Validar cliente no banco</li>
    <li>"/costumer/register" => POST - Registrar cliente o banco de dados</li>
</ul>