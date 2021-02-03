# Serverless Test

Used to demo some features of the serverless framework.

## Prerequisites

### Installing Serverless CLI

First, install [Serverless](https://www.serverless.com/framework/docs/getting-started/).

For Windows users:
- If you have chocolatey installed, run `choco install serverless`
- otherwise, install [Node.js](https://nodejs.org/en/) and then run `npm install -g serverless`.

Check that serverless is installed by running the `serverless` command in a CLI. 

### Creating an AWS Account

To run the project, we will use AWS.

First, create an account with [AWS](https://aws.amazon.com/) (if you don't have on already).

### Adding a user

Now that you have an account, we are going to create a user to sign in with on the command line.

Open the AWS console. Search for `IAM` in the box at the top, and go to the `IAM Dashboard` (first result). In the `Access Management` section on the left, select `Users`.

Click the `Add User` button, and create a user with the name "serverless-user". Tick the `Programmatic access` box - this will enable us to login using Serverless. 

On the next tab, click the `Attach existing policies directly` tab, and tick the `AdministratorAccess` policy. Once you are more comfortable with AWS, you should go back and tune the policy options until it does exactly what you need and no more.

Skip the `Add tags` step, and then click `Create User` on the `Review` page.

### Configuring Serverless.

Now that you have created a user, we need to add its credentials to the Serverless CLI. Go to the `IAM/Users` page, and click the user you created in the previous step.

Select the `Security credentials` tab, and click `Create access key`. Do not close the popup yet, or you will have to create a new user.

Now, go to your terminal and run the following command, substituting the access key ID and secret access key placeholders (remove the <>).

`serverless config credentials --provider aws --key <access_key_id> --secret <secret_access_key>`

If you make a mistake, you can overwrite your mistake by appending `--overwrite` to the above command.

## Clone

Now that setup is done, clone this repository into a folder of your choosing.

`git clone https://github.com/mileswatson/serverless-test.git`

Congratulations! You are now ready to build and deploy the project.

## Build

CD into the serverless-test directory, and then run the respective command to compile the code.

#### Windows

`./build.cmd`

#### Linux

`./build.sh`

## Deploy

You are now ready to deploy the code to AWS! You can deploy to two stages - `dev` (used for testing) and `prod` (production, the "real world" deployment). 

Deployment may take a minute or two. Be patient!

#### Development

`serverless deploy` or `serverless deploy --stage dev`

#### Production

`serverless deploy --stage prod`

## Verify

You can check that you have deployed successfully by searching for "CloudFormation" in the AWS console. You should be able to see a stack titled `backend-dev` (or `backend-prod`). Click it, and click Resources to see a list of all the items that were deployed.

## Remove

You can remove your deployment with the `serverless remove` command (remember to append `--stage prod` if you want to remove the production stack).
