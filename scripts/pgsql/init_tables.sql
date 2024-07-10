--#region 环境基础数据
CREATE TABLE IF NOT EXISTS toyar_environment
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    english_name VARCHAR(50) NOT NULL DEFAULT '',
    chines_name VARCHAR(50) NOT NULL DEFAULT '',
    is_system_default BOOLEAN NOT NULL DEFAULT false,
    deleted BOOLEAN NOT NULL DEFAULT false,
    create_user_name VARCHAR(50) NOT NULL DEFAULT '',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX idx_toyar_environment_id on toyar_environment (id);
CREATE INDEX idx_toyar_environment_english_name on toyar_environment (english_name);
CREATE INDEX idx_toyar_environment_chines_name on toyar_environment (chines_name);

COMMENT ON COLUMN "toyar_infra"."toyar_environment"."id" IS '唯一标识';
COMMENT ON COLUMN "toyar_infra"."toyar_environment"."english_name" IS '英文名称';
COMMENT ON COLUMN "toyar_infra"."toyar_environment"."chines_name" IS '中文名称';
COMMENT ON COLUMN "toyar_infra"."toyar_environment"."is_system_default" IS '是否系统默认';  
COMMENT ON COLUMN "toyar_infra"."toyar_environment"."deleted" IS '是否删除';
COMMENT ON COLUMN "toyar_infra"."toyar_environment"."create_user_name" IS '创建人';
COMMENT ON COLUMN "toyar_infra"."toyar_environment"."create_user_id" IS '创建人Id';
COMMENT ON COLUMN "toyar_infra"."toyar_environment"."creation_time" IS '创建时间';
COMMENT ON COLUMN "toyar_infra"."toyar_environment"."last_modification_user_name" IS '最后修改人';
COMMENT ON COLUMN "toyar_infra"."toyar_environment"."last_modification_user_id" IS '最后修改人Id';
COMMENT ON COLUMN "toyar_infra"."toyar_environment"."last_modification_time" IS '最后修改时间';
COMMENT ON COLUMN "toyar_infra"."toyar_environment"."deletion_time" IS '删除时间';

INSERT INTO toyar_environment (id, english_name, chines_name, is_system_default, create_user_name, create_user_id, last_modification_user_name, last_modification_user_id) 
VALUES ('580302534535569409', 'qa', '开发联调环境', true, 'system', '580302534690758661', 'system', '580302534690758661');

INSERT INTO toyar_environment (id, english_name, chines_name, is_system_default, create_user_name, create_user_id, last_modification_user_name, last_modification_user_id) 
VALUES ('580302534690758658', 'uat', '质量保证环境', true, 'system', '580302534690758661', 'system', '580302534690758661');

INSERT INTO toyar_environment (id, english_name, chines_name, is_system_default, create_user_name, create_user_id, last_modification_user_name, last_modification_user_id) 
VALUES ('580302534690758659', 'stage', '预发环境', true, 'system', '580302534690758661', 'system', '580302534690758661');

INSERT INTO toyar_environment (id, english_name, chines_name, is_system_default, create_user_name, create_user_id, last_modification_user_name, last_modification_user_id) 
VALUES ('580302534690758660', 'product', '生产环境', true, 'system', '580302534690758661', 'system', '580302534690758661');

--#endregion

--#region 基础组件
CREATE TABLE IF NOT EXISTS toyar_base_component
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    english_name VARCHAR(50) NOT NULL DEFAULT '',
    chines_name VARCHAR(50) NOT NULL DEFAULT '',
    url VARCHAR(500) NOT NULL DEFAULT '',
    certificate_type int NOT NULL DEFAULT 0,
    token VARCHAR(500) NOT NULL DEFAULT '',
    account VARCHAR(500) NOT NULL DEFAULT '',
    password VARCHAR(500) NOT NULL DEFAULT '',
    deleted BOOLEAN NOT NULL DEFAULT false,
    create_user_name VARCHAR(50) NOT NULL DEFAULT '',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);

--#endregion
    

--#region 角色基础数据
CREATE TABLE IF NOT EXISTS toyar_role
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    english_name VARCHAR(50) NOT NULL DEFAULT '',
    chines_name VARCHAR(50) NOT NULL DEFAULT '',
    deleted BOOLEAN NOT NULL DEFAULT false,
    create_user_name VARCHAR(50) NOT NULL DEFAULT '',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX idx_toyar_role_id on toyar_role (id);
CREATE INDEX idx_toyar_role_english_name on toyar_role (english_name);
CREATE INDEX idx_toyar_role_chines_name on toyar_role (chines_name);

COMMENT ON COLUMN "toyar_infra"."toyar_role"."id" IS '唯一标识';
COMMENT ON COLUMN "toyar_infra"."toyar_role"."english_name" IS '英文名称';
COMMENT ON COLUMN "toyar_infra"."toyar_role"."chines_name" IS '中文名称';
COMMENT ON COLUMN "toyar_infra"."toyar_role"."deleted" IS '是否删除';
COMMENT ON COLUMN "toyar_infra"."toyar_role"."create_user_name" IS '创建人';
COMMENT ON COLUMN "toyar_infra"."toyar_role"."create_user_id" IS '创建人Id';
COMMENT ON COLUMN "toyar_infra"."toyar_role"."creation_time" IS '创建时间';
COMMENT ON COLUMN "toyar_infra"."toyar_role"."last_modification_user_name" IS '最后修改人';
COMMENT ON COLUMN "toyar_infra"."toyar_role"."last_modification_user_id" IS '最后修改人Id';
COMMENT ON COLUMN "toyar_infra"."toyar_role"."last_modification_time" IS '最后修改时间';
COMMENT ON COLUMN "toyar_infra"."toyar_role"."deletion_time" IS '删除时间';
--#endregion

--#region 应用基础数据
CREATE TABLE IF NOT EXISTS toyar_application
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    app_id VARCHAR(50) NOT NULL DEFAULT '',
    app_name VARCHAR(50) NOT NULL DEFAULT '',
    module_git VARCHAR(300) NOT NULL DEFAULT '',
    app_type VARCHAR(50) NOT NULL DEFAULT '',
    owned_user VARCHAR(50) NOT NULL DEFAULT '',
    instance_type  int NOT NULL DEFAULT 0,
    app_deploy_status_type VARCHAR(50) NOT NULL DEFAULT '',
    note VARCHAR(150) NOT NULL DEFAULT '',
    is_use_deploy_template BOOLEAN NOT NULL DEFAULT false,
    deleted BOOLEAN NOT NULL DEFAULT false,
    create_user_name VARCHAR(50) NOT NULL DEFAULT '',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);

CREATE INDEX idx_toyar_app_id on toyar_application (id);
CREATE INDEX idx_toyar_app_app_id on toyar_application (app_id);
CREATE INDEX idx_toyar_app_app_name on toyar_application (app_name);

COMMENT ON COLUMN "toyar_infra"."toyar_application"."id" IS '唯一标识';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."app_id" IS '应用标识（系统唯一）';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."app_name" IS '应用名称';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."module_git" IS 'Git仓库地址';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."app_type" IS '应用类型';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."owned_user" IS '应用负责人';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."instance_type" IS '实例类型';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."app_deploy_status_type" IS '应用状态';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."note" IS '应用介绍';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."is_use_deploy_template" IS '是否使用默认部署模板';     
COMMENT ON COLUMN "toyar_infra"."toyar_application"."deleted" IS '是否删除';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."create_user_name" IS '创建人';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."create_user_id" IS '创建人Id';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."creation_time" IS '创建时间';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."last_modification_user_name" IS '最后修改人';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."last_modification_user_id" IS '最后修改人Id';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."last_modification_time" IS '最后修改时间';
COMMENT ON COLUMN "toyar_infra"."toyar_application"."deletion_time" IS '删除时间';

--#endregion

--#region 应用部署配置信息表
CREATE TABLE IF NOT EXISTS toyar_application_deployment_configuration
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    app_id VARCHAR(50) NOT NULL DEFAULT '',
    environment_id VARCHAR(50) NOT NULL DEFAULT '',
    health_check_mode VARCHAR(50) NOT NULL DEFAULT '',
    health_check_url VARCHAR(50) NOT NULL DEFAULT '',
    release_strategy VARCHAR(50) NOT NULL DEFAULT '',
    service_port  VARCHAR(300) NOT NULL DEFAULT '',
    bot_notification_type  VARCHAR(50) NOT NULL DEFAULT '',
    bot_notification_url  VARCHAR(50) NOT NULL DEFAULT '',
    deployment_before_web_hook_url  VARCHAR(50) NOT NULL DEFAULT '',
    deployment_after_web_hook_url  VARCHAR(50) NOT NULL DEFAULT '',
    restart_policy  VARCHAR(50) NOT NULL DEFAULT '',
    memory_size_maxmib VARCHAR(50) NOT NULL DEFAULT '',
    cpu  VARCHAR(50) NOT NULL DEFAULT '',
    container_pattern int NOT NULL DEFAULT 0,
    environment_variable VARCHAR(1000) NOT NULL DEFAULT '',
    mounts VARCHAR(1000) NOT NULL DEFAULT '',
    is_default_deployment BOOLEAN NOT NULL DEFAULT false, 
    deleted BOOLEAN NOT NULL DEFAULT false,
    create_user_name VARCHAR(50) NOT NULL DEFAULT '',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);
CREATE INDEX idx_toyar_application_deployment_configuration_id on toyar_application_deployment_configuration (id);
CREATE INDEX idx_toyar_application_deployment_configuration_app_id on toyar_application_deployment_configuration (app_id);
CREATE INDEX idx_toyar_application_deployment_configuration_environment_id on toyar_application_deployment_configuration (environment_id);

COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."id" IS '唯一标识';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."app_id" IS '应用标识（系统唯一）外键';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."environment_id" IS '环境Id';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."health_check_mode" IS '健康检查方式';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."health_check_url" IS '健康检查url';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."release_strategy" IS '发布模式';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."service_port" IS '服务端口';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."bot_notification_type" IS '发布通知机器人类型：（企业微信、钉钉、飞书等）';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."bot_notification_url" IS '发布通知Url';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."deployment_before_web_hook_url" IS '部署前回调地址';     
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."deployment_after_web_hook_url" IS '部署后回调地址';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."restart_policy" IS '重启策略';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."memory_size_maxmib" IS '最大内存';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."cpu" IS 'Cpu数量';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."container_pattern" IS '容器模式';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."environment_variable" IS '环境变量';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."mounts" IS '挂载目录';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."is_default_deployment" IS '是否默认部署配置';     
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."deleted" IS '是否删除';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."create_user_name" IS '创建人';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."create_user_id" IS '创建人Id';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."creation_time" IS '创建时间';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."last_modification_user_name" IS '最后修改人';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."last_modification_user_id" IS '最后修改人Id';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."last_modification_time" IS '最后修改时间';
COMMENT ON COLUMN "toyar_infra"."toyar_application_deployment_configuration"."deletion_time" IS '删除时间';
--#endregion

--#region 应用权限关联关系表
CREATE TABLE IF NOT EXISTS toyar_application_permission_relation
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    app_id VARCHAR(50) NOT NULL DEFAULT '',
    user_id VARCHAR(50) NOT NULL DEFAULT '',
    environment_id VARCHAR(50) NOT NULL DEFAULT '',
    role_id VARCHAR(50) NOT NULL DEFAULT '',
    deleted BOOLEAN NOT NULL DEFAULT false,
    create_user_name VARCHAR(50) NOT NULL DEFAULT '',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);
CREATE INDEX idx_toyar_application_permission_relation_app_id on toyar_application_permission_relation (app_id);
CREATE INDEX idx_toyar_application_permission_relation_user_id on toyar_application_permission_relation (user_id);
CREATE INDEX idx_toyar_application_permission_relation_environment_id on toyar_application_permission_relation (environment_id);
CREATE INDEX idx_toyar_application_permission_relation_role_id on toyar_application_permission_relation (role_id);

COMMENT ON COLUMN "toyar_infra"."toyar_application_permission_relation"."id" IS '唯一标识';
COMMENT ON COLUMN "toyar_infra"."toyar_application_permission_relation"."app_id" IS '应用标识（系统唯一）';
COMMENT ON COLUMN "toyar_infra"."toyar_application_permission_relation"."user_id" IS '用户id';
COMMENT ON COLUMN "toyar_infra"."toyar_application_permission_relation"."environment_id" IS '环境Id';
COMMENT ON COLUMN "toyar_infra"."toyar_application_permission_relation"."role_id" IS '角色Id';
COMMENT ON COLUMN "toyar_infra"."toyar_application_permission_relation"."deleted" IS '是否删除';
COMMENT ON COLUMN "toyar_infra"."toyar_application_permission_relation"."create_user_name" IS '创建人';
COMMENT ON COLUMN "toyar_infra"."toyar_application_permission_relation"."create_user_id" IS '创建人Id';
COMMENT ON COLUMN "toyar_infra"."toyar_application_permission_relation"."creation_time" IS '创建时间';
COMMENT ON COLUMN "toyar_infra"."toyar_application_permission_relation"."last_modification_user_name" IS '最后修改人';
COMMENT ON COLUMN "toyar_infra"."toyar_application_permission_relation"."last_modification_user_id" IS '最后修改人Id';
COMMENT ON COLUMN "toyar_infra"."toyar_application_permission_relation"."last_modification_time" IS '最后修改时间';
COMMENT ON COLUMN "toyar_infra"."toyar_application_permission_relation"."deletion_time" IS '删除时间';


--#endregion

--#region  应用环境关联关系表
CREATE TABLE IF NOT EXISTS toyar_application_environment_relation
(
    id VARCHAR(50) NOT NULL PRIMARY KEY,
    app_id VARCHAR(50) NOT NULL DEFAULT '',
    environment_id VARCHAR(50) NOT NULL DEFAULT '',
    deleted BOOLEAN NOT NULL DEFAULT false,
    create_user_name VARCHAR(50) NOT NULL DEFAULT '',
    create_user_id VARCHAR(50) NOT NULL DEFAULT '',
    creation_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    last_modification_user_name VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_user_id VARCHAR(50) NOT NULL DEFAULT '',
    last_modification_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    deletion_time TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP
);
CREATE INDEX idx_toyar_application_environment_relation_app_id on toyar_application_environment_relation (app_id);
CREATE INDEX idx_toyar_application_environment_relation_environment_id on toyar_application_environment_relation (environment_id);

COMMENT ON COLUMN "toyar_infra"."toyar_application_environment_relation"."id" IS '唯一标识';
COMMENT ON COLUMN "toyar_infra"."toyar_application_environment_relation"."app_id" IS '应用标识（系统唯一）';
COMMENT ON COLUMN "toyar_infra"."toyar_application_environment_relation"."environment_id" IS '环境Id';
COMMENT ON COLUMN "toyar_infra"."toyar_application_environment_relation"."deleted" IS '是否删除';
COMMENT ON COLUMN "toyar_infra"."toyar_application_environment_relation"."create_user_name" IS '创建人';
COMMENT ON COLUMN "toyar_infra"."toyar_application_environment_relation"."create_user_id" IS '创建人Id';
COMMENT ON COLUMN "toyar_infra"."toyar_application_environment_relation"."creation_time" IS '创建时间';
COMMENT ON COLUMN "toyar_infra"."toyar_application_environment_relation"."last_modification_user_name" IS '最后修改人';
COMMENT ON COLUMN "toyar_infra"."toyar_application_environment_relation"."last_modification_user_id" IS '最后修改人Id';
COMMENT ON COLUMN "toyar_infra"."toyar_application_environment_relation"."last_modification_time" IS '最后修改时间';
COMMENT ON COLUMN "toyar_infra"."toyar_application_environment_relation"."deletion_time" IS '删除时间';

--#endregion
