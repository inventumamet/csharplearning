resource "aws_iam_role" "iam_for_lambda" {
  name = "iam_for_lambda"

  assume_role_policy = <<EOF
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Action": "sts:AssumeRole",
      "Principal": {
        "Service": "lambda.amazonaws.com"
      },
      "Effect": "Allow",
      "Sid": ""
    }
  ]
}
EOF
}

provider "aws" {
  profile = "maoneng-sandbox"
  region  = "ap-southeast-2"
}

resource "aws_lambda_function" "test_lambda" {
  filename      = "out.zip"
  function_name = "SimpleFunction"
  role          = aws_iam_role.iam_for_lambda.arn
  # {DLL name}::{namspace}.{classname}::{handler functio name}
  handler       = "SimpleFunction::SimpleFunction.Function::FunctionHandler"

  # The filebase64sha256() function is available in Terraform 0.11.12 and later
  # For Terraform 0.11.11 and earlier, use the base64sha256() function and the file() function:
  # source_code_hash = "${base64sha256(file("out.zip"))}"
  source_code_hash = filebase64sha256("out.zip")

  runtime = "dotnetcore3.1"

  environment {
    variables = {
      foo = "bar"
    }
  }
}